using System;
using System.ComponentModel.DataAnnotations;

namespace Intra.Models
{
    public class UserViewModel
    { 
        public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class RegisterUser : BaseEntity
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MinLength(2, ErrorMessage = "A minimum of 2 is allowed for name")]
        [MaxLength(130, ErrorMessage = "A maximum of 30 is allowed for name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Your name must only contain letters")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(4, ErrorMessage = "A minimum length of 4")]
        [MaxLength(20, ErrorMessage = "A maximum length of 20")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string Confirm { get; set; }
    }

        public class LoginUser : BaseEntity
        {
            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "This is an email field")]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [MinLength(4, ErrorMessage = "A minimum length of 4")]
            [MaxLength(20, ErrorMessage = "A maximum length of 20")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]

            public string Password { get; set; }
        }
    }
}
