using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using EMS.Data.Models;
using EMS.Data.GetModels;
using EMS.Service;
using EMS.Data.ViewModels;
using EMS.API.Ulities;

namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/File")]
    public class FileController : Controller
    {
        private readonly EMSContext _context;
        private readonly PageService _service;
        public FileController(EMSContext context)
        {
            _context = context;
            _service = new PageService(_context);
        }

        [HttpPost("uploads")]
        public async Task<IActionResult> Uploads(List<IFormFile> files)
        {
            try
            {
                var result = new List<PageDetail>();
                foreach (var file in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                     "wwwroot/Image", "2" + ".jpg");
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);
                    result.Add(new PageDetail() { });
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("tests")]
      //  [Produces("application/json")]
      //  [Consumes("application/json")]

        public IActionResult Test([FromBody] IFormFile f)
        {
            try
            {
               
                return Ok();
            }
            catch
            {
                return BadRequest();


            }

        }

        [HttpPost("test")]
        //  [Produces("application/json")]
        //  [Consumes("application/json")]

        public  IActionResult Tests([FromForm] GetPageDetails form)
        {
            try
            {
                string res="";
                if (form.DefImage != null)
                {
                     res = AddFile.AddImage(form.DefImage, form.Id);
                }
                
                var result = new List<String>();
                if (form.Image != null)
                {
                    result = AddFile.AddImages(form.Image, form.Id);
                }
                
                    PageDetail det = new PageDetail();
                    det.Id = form.Id;
                    det.Topic = form.Topic;
                    det.SubTopic = form.SubTopic;
                    det.Type = form.Type;
                    det.Dis1 = form.Dis1;
                    det.Dis2 = form.Dis2;
                    det.Dis3 = form.Dis3;
                    det.DefImage = res;

                    det.IsActive = true;
                    if ((_service.AddPageDetails(det) && _service.AddImageName(result,form.Id)))
                    {
                        return Ok(result);
                    }

                return BadRequest();
            }
            catch
            {
                return BadRequest();


            }


        }

        [HttpGet("getpage/{id}")]

        public IActionResult Getpage(string id)
        {
            try {
                
                var page = _service.GetPage(id);
                
                return Ok( page);
            }
            catch { return BadRequest(); }
        }

        [HttpPost("uploadimages")]
        public IActionResult UploadImages([FromForm] ImagesUpload form)
        {
            try
            {
                var result = new List<String>();
                if (form.Image != null)
                {
                    result = AddFile.AddImages(form.Image, form.Id);
                }
                var im = _service.AddImageName(result, form.Id);

                return Ok(im);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("uploadpage")]
        public IActionResult UpdatePage(GetPageDetails form)
        {
            string res = "";
            if (form.DefImage != null)
            {
                res = AddFile.AddImage(form.DefImage, form.Id);
            }

            var result = new List<String>();
            if (form.Image != null)
            {
                result = AddFile.AddImages(form.Image, form.Id);
            }

            PageDetail det = new PageDetail();
            det.Id = form.Id;
            det.Topic = form.Topic;
            det.SubTopic = form.SubTopic;
            det.Type = form.Type;
            det.Dis1 = form.Dis1;
            det.Dis2 = form.Dis2;
            det.Dis3 = form.Dis3;
            det.IsActive = true;
            if(form.DefImage != null) { det.DefImage = res;}
            
            
            try {
                var im = _service.AddImageName(result, form.Id);
                var up = _service.UpdatePage(det);
                if (up && im)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch { return BadRequest(); }
             
        }

        [HttpGet("getimage/{id}")]

        public IActionResult GetImages(string id)
        {
            try
            {
                var image = new List<Images>();
               // var page = _service.GetPage(id);
                image = _service.GetImages(id);
                return Ok(image);
            }
            catch { return BadRequest(); }
        }

        [HttpGet("allgetimage/{id}")]

        public IActionResult AllGetImages(string id)
        {
            try
            {
                var image = new List<Images>();
                // var page = _service.GetPage(id);
                image = _service.AllGetImages(id);
                return Ok(image);
            }
            catch { return BadRequest(); }
        }


        [HttpGet("getpagestopic")]
        public List<GetPageId> GetPages()
        {
            try { return _service.GetPages(); }
            catch { return null; }
        }

        [HttpGet("gettopicid")]
        public IActionResult GetImageTopics()
        {
            try {
                var s = _service.GetImageTopics();
               
                
                return Ok(s);
            }
            catch { return null; }
        }
        [HttpGet("deactivepage/{id}")]
        public Boolean DeActivePage(string id)
        {
            return _service.DeActivePage(id);
        }

        [HttpGet("activepage/{id}")]
        public Boolean ActivePage(string id)
        {
            return _service.ActivePage(id);
        }
        [HttpPost("deactiveimage")]
        public Boolean DeActiveImage([FromForm] GetId form)
        {
            return _service.DeActiveImage(form.Id);
        }

        [HttpPost("activeimage")]
        public Boolean ActiveImage([FromForm] GetId form)
        {
            return _service.ActiveImage(form.Id);
        }

        [HttpGet("getallpages")]
        public IActionResult AllGetPages()
        {
            try { var test = _service.AllGetPages();
                return Ok(test);
            }
            catch { return null; }
            
        }

    }
}