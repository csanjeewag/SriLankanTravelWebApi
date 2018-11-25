using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/subpart")]
    public class SubPartController : Controller
    {
        private readonly EMSContext _context;
        private readonly SubPartService _service;
        public SubPartController(EMSContext context)
        {
            _context = context;
            _service = new SubPartService(_context);
        }
        [HttpPost("addtype")]
        public IActionResult AddType(PageType type)
        {
            try {

              var test =  _service.AddType(type);
                if (test) { return Ok(); } else { return BadRequest(); }
            } catch
            {
                return BadRequest();
            }
            
        }
        [HttpPost("updatetype")]
        public IActionResult UpdateType(PageType type)
        {
            try
            {

                var test = _service.UpadateType(type);
                if (test) { return Ok(); } else { return BadRequest(); }
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("gettype")]
        public IActionResult GetType()
        {
            try
            {
                var test = _service.GetTypes();
                return Ok(test);
            }
            catch { return BadRequest(); }
            
        }
        [HttpGet("gettypes")]
        public IActionResult GetTypes()
        {
            try
            {
                var test = _service.GetTypes();
               var types = test.Where(c => c.IsActive == true).ToList();
                return Ok(types);
            }
            catch { return BadRequest(); }

        }
        [HttpGet("gettype/{id}")]
        public IActionResult GetType(string id)
        {
            try
            {
                var test = _service.GetType(id);
                return Ok(test);
            }
            catch { return BadRequest(); }
           
        }

        [HttpGet("deactivetype/{id}")]
        public IActionResult DeActiveType(string id)
        {
            try { var test = _service.DeActiveType(id);
                if (test) { return Ok(test); } else { return BadRequest(test); }
            } catch
            {
                return BadRequest();
            }
            

        }
        [HttpGet("activetype/{id}")]
        public IActionResult ActiveType(string id)
        {
            try
            {
                var test = _service.ActiveType(id);
                if (test) { return Ok(test); } else { return BadRequest(test); }
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}