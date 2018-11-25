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
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
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
                    det.UsersEmail = form.Author;
                   det.District = form.District;
                   det.Town = form.Town;
                det.Location = form.location;
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
        [Authorize]
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
        [Authorize]
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
            det.District = form.District;
            det.Town = form.Town;
            det.Location = form.location;
            if (form.DefImage != null) { det.DefImage = res;}
            
            
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

        [Authorize]
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
        [HttpGet("gettopicid/{type}")]
        public IActionResult GetImageTopics(string type)
        {
            try
            {

                var test = _service.GetImageTopics();
                if (type == "" || type == null)
                {
                    return Ok(test);
                }
                else
                {
                    var test2 = test.Where(c => c.Type == type).ToList();
                    return Ok(test2);
                }

            }
            catch { return null; }
        }
        [Authorize]
        [HttpGet("deactivepage/{id}")]
        public IActionResult DeActivePage(string id)
        {
            try
            {
                var test = _service.DeActivePage(id);
                if (test) { return Ok(id); } else { return BadRequest(id); }
            }
            catch { return BadRequest(id); }
        }
        [Authorize]
        [HttpGet("activepage/{id}")]
        public IActionResult ActivePage(string id)
        {
            try
            {
                var test = _service.ActivePage(id);
                if (test) { return Ok(id); } else { return BadRequest(id); }
            }
            catch { return BadRequest(id); }
        }
        [Authorize]
        [HttpPost("deactiveimage")]
        public Boolean DeActiveImage([FromForm] GetId form)
        {
            return _service.DeActiveImage(form.Id);
        }

        [Authorize]
        [HttpPost("activeimage")]
        public Boolean ActiveImage([FromForm] GetId form)
        {
            return _service.ActiveImage(form.Id);
        }
        [Authorize]
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