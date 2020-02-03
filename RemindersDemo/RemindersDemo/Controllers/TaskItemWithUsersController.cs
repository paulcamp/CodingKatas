using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RemindersDemo.Models;

namespace RemindersDemo.Controllers
{
    [Authorize]
    public class TaskItemWithUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TaskItemWithUsers
        public ActionResult Index()
        {
            var allTasks = db.TaskItemWithUsers.OrderByDescending(_ => _.DateCreated).ToList();

            //fill in the human readable usernames
            foreach (var task in allTasks)
            {
                task.AssignedUserName = db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
                task.EscalationUserName = db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;
            }

            return View(allTasks);
        }

        // GET: TaskItemWithUsers/Details/5
        public ActionResult Details(Guid? id)
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

            //fill in the human readable usernames
            task.AssignedUserName = db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
            task.EscalationUserName = db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;
            return View(task);
        }

        // GET: TaskItemWithUsers/Create
        public ActionResult Create()
        {
            var myUser = Guid.Parse(User.Identity.GetUserId());

            return View(new TaskItemWithUsers()
            {
                //set defaults for a new task
                OpenStatus = true,
                EscalationUser = myUser,
                DateCreated = DateTime.Today,
                DateDue = DateTime.Today,
                //populate the user dropdown data
                AvailableUsers = GetAllUsersExceptCurrent()
            } );
        }

        // POST: TaskItemWithUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AssignedUser,EscalationUser,Description,OpenStatus,DateCreated,DateDue")] TaskItemWithUsers taskItemWithUsers)
        {
            if (ModelState.IsValid)
            {
                taskItemWithUsers.Id = Guid.NewGuid();
                db.TaskItemWithUsers.Add(taskItemWithUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskItemWithUsers);
        }

        // GET: TaskItemWithUsers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var taskItemWithUsers = db.TaskItemWithUsers.Find(id);
            
            if (taskItemWithUsers == null)
            {
                return HttpNotFound();
            }

            taskItemWithUsers.AvailableUsers = GetAllUsersExceptCurrent();     
            return View(taskItemWithUsers);
        }

        // POST: TaskItemWithUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AssignedUser,EscalationUser,Description,OpenStatus,DateCreated,DateDue")] TaskItemWithUsers taskItemWithUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskItemWithUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskItemWithUsers);
        }

        // GET: TaskItemWithUsers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskItemWithUsers taskItemWithUsers = db.TaskItemWithUsers.Find(id);
            if (taskItemWithUsers == null)
            {
                return HttpNotFound();
            }
            return View(taskItemWithUsers);
        }

        // POST: TaskItemWithUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TaskItemWithUsers taskItemWithUsers = db.TaskItemWithUsers.Find(id);
            if (taskItemWithUsers == null)
            {
                return RedirectToAction("Index");
            }
            db.TaskItemWithUsers.Remove(taskItemWithUsers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetAllUsersExceptCurrent()
        {
            //Get all users except the current user
            var myUser = User.Identity.GetUserId();
            return (from dbUser in db.Users where dbUser.Id != myUser select new SelectListItem() {Text = dbUser.Email, Value = dbUser.Id}).ToList();
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
