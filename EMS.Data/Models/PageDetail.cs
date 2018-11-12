using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Data.Models
{
  public  class PageDetail
    {
        [Key]
        public string Id { get; set; }
        public string Topic { get; set; }
        public string SubTopic { get; set; }

        public string Type { get; set; }
        public string Dis1 { get; set; }
        public string Dis2 { get; set; }
        public string Dis3 { get; set; }
        public DateTime StartDate { get; set; }
        public Boolean IsActive { get; set; }
        public string DefImage { get; set; }
        public ICollection<Images> images { get; set; }
    }
}
