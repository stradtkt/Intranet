using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intra.Models
{
    public class Employee : UserViewModel.BaseEntity
    {
        [Key] public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Image is required")]
        [DataType(DataType.Upload)]
        public string Image { get; set; }
        public string WorkDept { get; set; }
        public string PhoneNo { get; set; }
        public string Job { get; set; }
        public DateTime HireDate { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
        public decimal Bonus { get; set; }
        public int UserId { get; set; }
        public User Users { get; set; }
        public List<Todo> Todos { get; set; }
        public List<Calendar> Calendars { get; set; }

        public Employee()
        {
            Calendars = new List<Calendar>();
            Todos = new List<Todo>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}