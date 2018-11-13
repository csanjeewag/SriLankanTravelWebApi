using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EMS.Data.GetModels
{
   public class GetPageDetails
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public string SubTopic { get; set; }

        public string Type { get; set; }
        public string Dis1 { get; set; }
        public string Dis2 { get; set; }
        public string Dis3 { get; set; }
        public string Author { get; set; }
        public IFormFile DefImage { get; set; }
        public List<IFormFile> Image { get; set; }
    }
}
