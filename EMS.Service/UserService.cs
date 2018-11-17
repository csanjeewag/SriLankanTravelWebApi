using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.GetModels;
using EMS.Data.Models;

namespace EMS.Service
{
  public  class UserService
    {
        private readonly EMS.Data.UserRepository _service;

        private readonly EMSContext _context;
        public UserService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.UserRepository(_context);


        }

        public int SignUpUser(User user)
        {
            return _service.SignUpUser(user);
        }

        public Boolean LoginUser(UserLogin user)
        {
            return _service.LoginUser(user);
        }
        public User GetUser(string email)
        {
            return _service.GetUser(email);
        }
        public List<User> GetUsers()
        {
            return _service.GetUsers();
        }
        public Boolean ToUser(string email)
        {
            return _service.ToUser(email);
        }
        public Boolean ToAdmin(string email)
        {
            return _service.ToAdmin(email);
        }
        public Boolean Register(RegUser reg)
        {
            return _service.Register(reg);
        }

        public Boolean SetPassword(RegUser reg)
        {
            return _service.SetPassword(reg);
        }

        public string forgetpassword(string email)
        {
            return _service.forgetpassword(email);
        }
    }
}
