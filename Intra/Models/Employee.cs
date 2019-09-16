using System;
using System.ComponentModel.DataAnnotations;

namespace Intra.Models
{
    public class Employee
    {
        [Key] public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Image is required")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        public string WorkDept { get; set; }
        public string PhoneNo { get; set; }
        public string Job { get; set; }
        public DateTime HireDate { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
        public decimal Bonus { get; set; }
        
    }
}