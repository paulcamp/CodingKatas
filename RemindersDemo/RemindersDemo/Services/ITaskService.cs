using System.Collections.Generic;
using RemindersDemo.Models;

namespace RemindersDemo.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskItemWithUsers> GetFullyPopulatedTasks();

        IEnumerable<ReminderItem> GetReminders(string userId);
    }
}