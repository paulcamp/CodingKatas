using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemindersDemo.Models
{
    [NotMapped]
    public class ReminderItem
    {
        public Guid Id { get; set; }
        public Guid AssignedUser { get; set; }
        public string AssignedUserName { get; set; }
        public Guid EscalationUser { get; set; }
        public string EscalationUserName { get; set; }
        public string Description { get; set; }
        [UIHint("_IsOpen")]
        public bool OpenStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateDue { get; set; }
        public bool OverDue { get; set; }
        public bool EscalatedByYou { get; set; }
    }
}