using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace RemindersDemo.Models
{
    public class TaskItemWithUsers
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid AssignedUser { get; set; }
        [NotMapped]
        public string AssignedUserName { get; set; }
        [Required]
        public Guid EscalationUser { get; set; }
        [NotMapped]
        public string EscalationUserName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [UIHint("_IsOpen")]
        public bool OpenStatus { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateDue { get; set; }
        [NotMapped]
        public List<SelectListItem> AvailableUsers { get; set; }
    }
}