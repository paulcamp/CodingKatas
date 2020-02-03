using System;
using RemindersDemo.Models;

namespace RemindersDemo.Mappers
{
    public static class ModelMapper
    {
        public static ReminderItem Map(TaskItemWithUsers taskItem, Guid currentUser)
        {
            return new ReminderItem()
            {
                Id = taskItem.Id,
                AssignedUser = taskItem.AssignedUser,
                AssignedUserName = taskItem.AssignedUserName,
                EscalationUser = taskItem.EscalationUser,
                EscalationUserName = taskItem.EscalationUserName,
                DateCreated = taskItem.DateCreated,
                Description = taskItem.Description,
                DateDue = taskItem.DateDue,
                OpenStatus = taskItem.OpenStatus,
                OverDue = taskItem.DateDue < DateTime.Today,
                EscalatedByYou = taskItem.EscalationUser == currentUser
            };
        }
    }
}