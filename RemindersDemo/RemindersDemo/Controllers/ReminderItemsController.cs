using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RemindersDemo.Mappers;
using RemindersDemo.Models;

namespace RemindersDemo.Controllers
{
    [Authorize]
    public class ReminderItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReminderItems
        public ActionResult Index()
        {
            var allTasks = db.TaskItemWithUsers.ToList();
            var allReminders = new List<ReminderItem>();
            var myUser = Guid.Parse(User.Identity.GetUserId());

            //map to reminder items 
            foreach (var task in allTasks)
            {
                //show tasks I have been assigned
                if (task.AssignedUser == myUser && task.OpenStatus)
                {
                    task.AssignedUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
                    task.EscalationUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;

                    var reminderItem = ModelMapper.Map(task, myUser);
                    allReminders.Add(reminderItem);
                }

                //show tasks I escalated that are overdue
                if (task.EscalationUser == myUser && task.OpenStatus && task.DateDue < DateTime.Today)
                {
                    task.AssignedUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
                    task.EscalationUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;
                    var reminderItem = ModelMapper.Map(task, myUser);
                    allReminders.Add(reminderItem);
                }
            }

            //present in reverse chronological order
            return View(allReminders.OrderByDescending(_ => _.DateDue));
        }

        // GET: TaskItemWithUsers/Complete/Guid
        public ActionResult Complete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskItemWithUsers task = db.TaskItemWithUsers.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }

            var myUser = Guid.Parse(User.Identity.GetUserId());
            var reminderItem = ModelMapper.Map(task, myUser);
            return View(reminderItem);
        }

        // POST: TaskItemWithUsers/Complete/Guid
        [HttpPost, ActionName("Complete")]
        [ValidateAntiForgeryToken]
        public ActionResult CompleteConfirmed(Guid id)
        {
            TaskItemWithUsers taskItemWithUsers = db.TaskItemWithUsers.Find(id);
            if (taskItemWithUsers == null)
            {
                return RedirectToAction("Index");
            }

            taskItemWithUsers.OpenStatus = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
