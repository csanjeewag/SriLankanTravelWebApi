using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.GetModels;
using EMS.Data.Models;

namespace EMS.Data
{
   public class UserRepository
    {
        private readonly EMSContext _context;
        public UserRepository(EMSContext context)
        {
            _context = context;
        }

        public int SignUpUser(User user)
        {
            try
            {
                Employee employee = new Employee();
                Random rand = new Random((int)DateTime.Now.Ticks);
                int code = rand.Next(1000, 9999);

                DateTime today = DateTime.Today;
                user.StartDate = today;
                user.Key = code.ToString();
                user.Active = false;
                _context.Users.Add(user);
                _context.SaveChanges();
                return code;
            }
            catch
            {
                return 0;
            }

        }
        public Boolean LoginUser(UserLogin user)
        {
            var text = _context.Users
                .Where(c => c.Email == user.Email)
                .Where(c => c.Password == user.Password)
                .Where(c=> c.Active==true)
                .Select(c => c.Email)
                .FirstOrDefault(); 
            if (text == null)
            {
                return false;
            }
            else { return true; }

        }

        public User GetUser(string email)
        {
            try
            {
                var text = _context.Users
                    .Where(c => c.Email == email)
                    
                    .FirstOrDefault();
                return text;
            }
            catch
            {
                return null;
            }


        }
        public List<User> GetUsers()
        {
            try
            {
                var text = _context.Users
                        .Where(c => c.Active == true)
                         .ToList();
                return text;
            }
            catch
            {
                return null;
            }


        }

        public Boolean ToAdmin(string email)
        {
            try
            {
                User user = new User();
                user = _context.Users
                    .Where(c => c.Email == email)
                    .Where(c => c.Active == true)
                    .FirstOrDefault();
                user.Role = "admin";

                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean ToUser(string email)
        {
            try
            {
                User user = new User();
                user = _context.Users
                    .Where(c => c.Email == email)
                    .Where(c => c.Active == true)
                    .FirstOrDefault();
                user.Role = "user";

                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean Register(RegUser r)
        {
            try
            {
                var text = _context.Users
             .Where(c => c.Email == r.Email && c.Key == r.Code)
             .Where(c => c.Active == false)
             
             .Select(c => c.Email)
             .FirstOrDefault();
                if (!(string.IsNullOrEmpty(text)))
                {
                    Employee employee = new Employee();
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    int code = rand.Next(1000, 9999);

                    User user = new User();
                    user = _context.Users.Where(c => c.Email == r.Email).FirstOrDefault();
                    user.Active = true;
                    user.Key = code.ToString();
                    _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                }
                return true;
            } catch { return false; }
           

        }


        public Boolean SetPassword(RegUser r)
        {
            try
            {
                var text = _context.Users
             .Where(c => c.Email == r.Email && c.Key == r.Code)
             .Where(c => c.Active == true)

             .Select(c => c.Email)
             .FirstOrDefault();
                if (!(string.IsNullOrEmpty(text)))
                {
                    Employee employee = new Employee();
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    int code = rand.Next(1000, 9999);

                    User user = new User();
                    user = _context.Users.Where(c => c.Email == r.Email).FirstOrDefault();
                    user.Active = true;
                    user.Password = r.Password;
                    user.Key = code.ToString();
                    _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }


        }
        public string forgetpassword(string email)
        {
            Employee employee = new Employee();
            Random rand = new Random((int)DateTime.Now.Ticks);
            int code = rand.Next(1000, 9999);
            User user = new User();
            user = _context.Users.Where(c => c.Email== email).FirstOrDefault();
            user.Key = code.ToString();
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            var text = _context.Users.Where(c => c.Email == email).Select(c => c.Key).FirstOrDefault();
            return text;
        }

    }
}

