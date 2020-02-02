using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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

            //TODO: map to reminder item - do in testable helper and reuse code in details method
            foreach (var task in allTasks)
            {
                //show tasks I have been assigned
                if (task.AssignedUser == myUser && task.OpenStatus)
                {
                    //TODO: mapping helper
                    task.AssignedUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
                    task.EscalationUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;
                    allReminders.Add(new ReminderItem()
                    {
                        Id = task.Id,
                        AssignedUser = task.AssignedUser,
                        AssignedUserName = task.AssignedUserName,
                        EscalationUser = task.EscalationUser,
                        EscalationUserName = task.EscalationUserName,
                        Description = task.Description,
                        DateCreated = task.DateCreated,
                        DateDue = task.DateDue,
                        OpenStatus = task.OpenStatus,
                        OverDue = task.DateDue < DateTime.Today
                    });
                }

                //show tasks I escalated that are overdue
                if (task.EscalationUser == myUser && task.OpenStatus && task.DateDue < DateTime.Today)
                {
                    //TODO: check not already in list
                    
                    //TODO: mapping helper
                    task.AssignedUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
                    task.EscalationUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;
                    allReminders.Add(new ReminderItem()
                    {
                        Id = task.Id,
                        AssignedUser = task.AssignedUser,
                        AssignedUserName = task.AssignedUserName,
                        EscalationUser = task.EscalationUser,
                        EscalationUserName = task.EscalationUserName,
                        DateCreated = task.DateCreated,
                        Description = task.Description,
                        DateDue = task.DateDue,
                        OpenStatus = task.OpenStatus,
                        OverDue = true,
                        EscalatedByYou = true
                                  
                    });
                }
            }
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

            //TODO: refactor with mapping helper
            var itemToComplete = new ReminderItem()
            {
                Id = task.Id,
                AssignedUser = task.AssignedUser,
                AssignedUserName = task.AssignedUserName,
                EscalationUser = task.EscalationUser,
                EscalationUserName = task.EscalationUserName,
                DateCreated = task.DateCreated,
                DateDue = task.DateDue,
                OpenStatus = task.OpenStatus,
                Description = task.Description,
                OverDue = task.DateDue < DateTime.Today
            };

            return View(itemToComplete);
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
            //db.TaskItemWithUsers.Remove(taskItemWithUsers);
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
