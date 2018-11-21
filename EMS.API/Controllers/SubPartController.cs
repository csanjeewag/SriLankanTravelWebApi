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
        [HttpGet("gettype")]
        public List<PageType> GetTypes()
        {
            return _service.GetTypes();
        }
        [HttpGet("deactivetype/{id}")]
        public Boolean DeActiveType(string id)
        {
            return _service.DeActiveType(id);

        }
        [HttpGet("activetype/{id}")]
        public Boolean ActiveType(string id)
        {
            return _service.ActiveType(id);

        }
    }
}