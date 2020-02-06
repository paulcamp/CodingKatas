using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RemindersDemo.Models;
using RemindersDemo.Services;

namespace RemindersDemo.Controllers
{
    [Authorize]
    public class TaskItemWithUsersController : Controller
    {
        private readonly IApplicationDbContext _db;
        private readonly IUserService _userService;
        private readonly ITaskService _taskService;

        public TaskItemWithUsersController(IApplicationDbContext db, IUserService userService, ITaskService taskService)
        {
            _db = db;
            _userService = userService;
            _taskService = taskService;
        }
        
        // GET: TaskItemWithUsers
        public ActionResult Index()
        {
            var allTasks = _taskService.GetFullyPopulatedTasks();
            return View(allTasks);
        }

        // GET: TaskItemWithUsers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskItemWithUsers task = _db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }

            //fill in the human readable usernames
            task.AssignedUserName = _db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
            task.EscalationUserName = _db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;
            return View(task);
        }

        // GET: TaskItemWithUsers/Create
        public ActionResult Create()
        {
            var myUser = User.Identity.GetUserId();
            var myUserGuid = Guid.Parse(myUser);

            return View(new TaskItemWithUsers()
            {
                //set defaults for a new task
                OpenStatus = true,
                EscalationUser = myUserGuid,
                DateCreated = DateTime.Today,
                DateDue = DateTime.Today,
                //populate the user dropdown data
                AvailableUsers = _userService.GetAllUsersExceptCurrent(myUser).ToList()
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
                _db.Tasks.Add(taskItemWithUsers);
                _db.SaveChanges();
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
            
            var taskItemWithUsers = _db.Tasks.Find(id);
            
            if (taskItemWithUsers == null)
            {
                return HttpNotFound();
            }

            var myUser = User.Identity.GetUserId();
            taskItemWithUsers.AvailableUsers = _userService.GetAllUsersExceptCurrent(myUser).ToList();
            return View(taskItemWithUsers);
        }

        // POST: TaskItemWithUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AssignedUser,EscalationUser,Description,OpenStatus,DateCreated,DateDue")] TaskItemWithUsers taskItemWithUsers)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(taskItemWithUsers).State = EntityState.Modified;
                _db.SaveChanges();
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
            TaskItemWithUsers taskItemWithUsers = _db.Tasks.Find(id);
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
            TaskItemWithUsers taskItemWithUsers = _db.Tasks.Find(id);
            if (taskItemWithUsers == null)
            {
                return RedirectToAction("Index");
            }
            _db.Tasks.Remove(taskItemWithUsers);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
