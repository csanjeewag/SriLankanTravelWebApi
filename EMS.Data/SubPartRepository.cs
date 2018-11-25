using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;

namespace EMS.Data
{
  public  class SubPartRepository
    {
        private readonly EMSContext _context;
        public SubPartRepository(EMSContext context)
        {
            _context = context;
        }

        public Boolean AddType(PageType type)
        {
            try {

                _context.PageTypes.Add(type);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public Boolean UpadateType( PageType type)
        {
            try
            { var test = _context.PageTypes.Where(c => c.TypeId == type.TypeId).Select(c=> new { c.IsActive}).FirstOrDefault();
                type.IsActive = test.IsActive;
                _context.Entry(type).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<PageType> GetTypes( )
        {
            var test =  _context.PageTypes.ToList();
             return test;
        }
        public PageType GetType(string id)
        {
            var test = _context.PageTypes.Where(c => c.TypeId == id).FirstOrDefault(); 
            return test;
        }

        public Boolean DeActiveType(string id)
        {
            // PageType type = new PageType()
            try {
                var type = _context.PageTypes.Where(c => c.TypeId == id).FirstOrDefault();
                type.IsActive = false;
                _context.Entry(type).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
              
        }

        public Boolean ActiveType(string id)
        {
            // PageType type = new PageType()
            try
            {
                var type = _context.PageTypes.Where(c => c.TypeId == id).FirstOrDefault();
                type.IsActive = true;
                _context.Entry(type).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }


    }
}
