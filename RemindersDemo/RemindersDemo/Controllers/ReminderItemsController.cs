using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RemindersDemo.Mappers;
using RemindersDemo.Models;
using RemindersDemo.Services;

namespace RemindersDemo.Controllers
{
    [Authorize]
    public class ReminderItemsController : Controller
    {
        private readonly IApplicationDbContext _db;
        private readonly ITaskService _taskService;

        public ReminderItemsController(IApplicationDbContext db, ITaskService taskService)
        {
            _db = db;
            _taskService = taskService;
        }

        // GET: ReminderItems
        public ActionResult Index()
        {
            var myUser =User.Identity.GetUserId();
            var allReminders = _taskService.GetReminders(myUser);
            
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
            TaskItemWithUsers task = _db.Tasks.Find(id);
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
            TaskItemWithUsers taskItemWithUsers = _db.Tasks.Find(id);
            if (taskItemWithUsers == null)
            {
                return RedirectToAction("Index");
            }

            taskItemWithUsers.OpenStatus = false;
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
