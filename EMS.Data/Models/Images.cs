using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
  public  class Images
    {
        [Key]
        public string ImageId { get; set; }
        [ForeignKey("PageDetail")]
        public string PageDetailsId { get; set; }
        public DateTime StartDate { get; set; }
        public Boolean IsActive { get; set; }
    }
}
