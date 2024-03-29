using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intra.Models
{
    public class Todo : UserViewModel.BaseEntity
    {
        [Key] public int TodoId { get; set; }
        public string TodoTitle { get; set; }
        public string TodoDescription { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employees { get; set; }

        public Todo()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}