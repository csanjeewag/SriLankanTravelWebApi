using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Data.Models
{
   public class User
    {
        [Key]
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime StartDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
