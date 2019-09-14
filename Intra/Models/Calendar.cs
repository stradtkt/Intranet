using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intra.Models
{
    public class Calendar : UserViewModel.BaseEntity
    {
        [Key] public int CalendarId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int UserId { get; set; }
        public User Users { get; set; }

        public Calendar()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}