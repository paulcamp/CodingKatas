using System;
using System.Collections.Generic;
using System.Linq;
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
                if (task.AssignedUser == myUser && task.OpenStatus == true)
                {
                    //TODO: mapping helper
                    task.AssignedUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
                    task.EscalationUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;
                    allReminders.Add(new ReminderItem()
                    {
                        AssignedUser = task.AssignedUser,
                        AssignedUserName = task.AssignedUserName,
                        EscalationUser = task.EscalationUser,
                        EscalationUserName = task.EscalationUserName,
                        DateCreated = task.DateCreated,
                        DateDue = task.DateDue,
                        OpenStatus = task.OpenStatus,
                        OverDue = task.DateDue < DateTime.Today
                    });
                }

                //show tasks I escalated that are overdue
                if (task.EscalationUser == myUser && task.OpenStatus == true && task.DateDue < DateTime.Today)
                {
                    //TODO: mapping helper
                    task.AssignedUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
                    task.EscalationUserName =
                        db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;
                    allReminders.Add(new ReminderItem()
                    {
                        AssignedUser = task.AssignedUser,
                        AssignedUserName = task.AssignedUserName,
                        EscalationUser = task.EscalationUser,
                        EscalationUserName = task.EscalationUserName,
                        DateCreated = task.DateCreated,
                        DateDue = task.DateDue,
                        OpenStatus = task.OpenStatus,
                        OverDue = task.DateDue < DateTime.Today
                    });
                }
            }
            return View(allReminders);
        }
        
        //TODO: some method to mark task as done

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
