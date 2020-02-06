using System;
using System.Collections.Generic;
using System.Linq;
using RemindersDemo.Mappers;
using RemindersDemo.Models;

namespace RemindersDemo.Services
{
    public class TaskService : ITaskService, IDisposable
    {
        private readonly IApplicationDbContext _db;

        public TaskService(IApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<TaskItemWithUsers> GetFullyPopulatedTasks()
        {
            var allTasks = _db.Tasks.OrderByDescending(_ => _.DateCreated).ToList();

            //fill in the human readable usernames
            foreach (var task in allTasks)
            {
                task.AssignedUserName = _db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
                task.EscalationUserName = _db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;
            }

            return allTasks;
        }

        public IEnumerable<ReminderItem> GetReminders(string userId)
        {
            var allTasks = _db.Tasks.ToList();
            var myUser = Guid.Parse(userId);
            var allReminders = new List<ReminderItem>();
            
            //map to reminder items 
            foreach (var task in allTasks)
            {
                //show tasks I have been assigned
                if (task.AssignedUser == myUser && task.OpenStatus)
                {
                    task.AssignedUserName =
                        _db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
                    task.EscalationUserName =
                        _db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;

                    var reminderItem = ModelMapper.Map(task, myUser);
                    allReminders.Add(reminderItem);
                }

                //show tasks I escalated that are overdue
                if (task.EscalationUser == myUser && task.OpenStatus && task.DateDue < DateTime.Today)
                {
                    task.AssignedUserName =
                        _db.Users.FirstOrDefault(x => x.Id == task.AssignedUser.ToString())?.UserName;
                    task.EscalationUserName =
                        _db.Users.FirstOrDefault(x => x.Id == task.EscalationUser.ToString())?.UserName;
                    var reminderItem = ModelMapper.Map(task, myUser);
                    allReminders.Add(reminderItem);
                }
            }

            return allReminders;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}