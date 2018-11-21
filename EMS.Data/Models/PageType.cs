using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Data.Models
{
  public  class PageType
    {
        [Key]
        public string TypeId { get; set; }
        public string TypeName { get; set; }
        public Boolean IsActive { get; set; }
        public string Discription { get; set; }
    }
}
