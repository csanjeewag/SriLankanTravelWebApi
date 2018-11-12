using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EMS.Data.GetModels
{
  public  class Test2
    {
        public string Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
