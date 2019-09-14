using System;
using System.ComponentModel.DataAnnotations;

namespace Intra.Models
{
    public class User : UserViewModel.BaseEntity
    {
        [Key] public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Rate { get; set; }
        public decimal Hours { get; set; }
        public DateTime Birthday { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}