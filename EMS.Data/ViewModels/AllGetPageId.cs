using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.ViewModels
{
   public class AllGetPageId
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public string SubTopic { get; set; }
        public string Type { get; set; }
        public string ImageId { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime StartDate { get; set; }
    }
}
