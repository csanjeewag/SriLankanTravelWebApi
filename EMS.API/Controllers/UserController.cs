using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.API.Ulities;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly EMSContext _context;
        private readonly UserService _service;
        public UserController(EMSContext context)
        {
            _context = context;
            _service = new UserService(_context);
        }


        [HttpPost("login")]
        public IActionResult Login([FromForm] UserLogin form)
        {


            try
            {
                var user = GetUser(form.Email);
                var Userrole = user.Role;
                var Userid = user.Email;
                var UserName = user.Fname;

                GetTokenModel token = GetToken.getToken(Userrole, Userid, UserName);

                var text = _service.LoginUser(form);
                if (text == true)
                {
                    return Ok(token);
                }
                else { return BadRequest(); }

            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPost("signup")]
        public IActionResult SignUpUser([FromForm] User user)
        {
            var Userrole = "";
            var Userid = "";
            var UserName = "";

            if (user.Email == "csanjeewag@gmail.com")
            {
                user.Role = "admin";
                 Userrole = user.Role;
                 Userid = user.Email;
                 UserName = user.Fname;
            }
            else
            {
                user.Role = "user";
                 Userrole = user.Role;
                Userid = user.Email;
                UserName = user.Fname;
            }



            try
            {


                var text = _service.SignUpUser(user);
                if (text > 0)
                {
                    GetTokenModel token = GetToken.getToken(Userrole, Userid, UserName);
                    Boolean SendCode = SendMail.SendloginCode(text.ToString(), user.Email, user.Fname);
                    return Ok(token);
                }
                else { return BadRequest(); }

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getuserdetail")]
        public User GetUser(string email)
        {
            return _service.GetUser(email);
        }

        [HttpGet("getuserdetails")]
        public IActionResult GetUsers()
        {
            try
            {
                var text = _service.GetUsers(); return Ok(text);
            }
            catch { return BadRequest(); }

        }
        [Authorize]
        [HttpGet("touser/{email}")]
        public Boolean ToUser(string email)
        {
            if(email == "csanjeewag@gmail.com")
            {
                return false;
            }
            return _service.ToUser(email);
        }
        [Authorize]
        [HttpGet("toadmin/{email}")]
        public Boolean ToAdmin(string email)
        {
            return _service.ToAdmin(email);
        }

        [HttpPost("register")]
        public IActionResult Register(RegUser reg)
        {
            
            if (_service.Register(reg))
            {
                return Ok();

            }
            else { return BadRequest(); }
        }

        [HttpGet("forgetpassword/{email}")]
        public IActionResult Forgetpassword(string email)
        {
            try
            {
                var code = _service.forgetpassword(email);
                if (string.IsNullOrEmpty(code)) { return BadRequest(); }
                else {
                    Boolean SendCode = SendMail.SendForgetPasswordCode(code, email, "Dear");
                    return Ok();
                }
            } catch { return BadRequest(); }
              

        }

        [HttpPost("setpassword")]
        public IActionResult SetPassword(RegUser reg)
        {

            if (_service.SetPassword(reg))
            {
                return Ok();

            }
            else { return BadRequest(); }
        }

    }
}