using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EMS.Data.GetModels
{
  public  class ImagesUpload
    {
        public string Id { get; set; }

        public List<IFormFile> Image { get; set; }
    }
}
