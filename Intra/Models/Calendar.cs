using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intra.Models
{
    public class Calendar : UserViewModel.BaseEntity
    {
        [Key] public int CalendarId { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Title { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employees { get; set; }

        public Calendar()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}