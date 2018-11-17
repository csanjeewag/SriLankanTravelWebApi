using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Data.Models
{
   public class User
    {
        [Key]
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime StartDate { get; set; }
        public Boolean Active { get; set; }
        public string Key { get; set; }
        public string Role { get; set; }
       
        public string Password { get; set; }

    }
}
