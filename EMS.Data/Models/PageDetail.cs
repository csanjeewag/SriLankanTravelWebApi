using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
  public  class PageDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Topic { get; set; }
        public string SubTopic { get; set; }

        [ForeignKey("User")]
        public string UsersEmail { get; set; }
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
