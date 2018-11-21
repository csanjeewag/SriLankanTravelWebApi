using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;

namespace EMS.Service
{
  public  class SubPartService
    {
        private readonly EMS.Data.SubPartRepository _service;

        private readonly EMSContext _context;
        public SubPartService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.SubPartRepository(_context);
        }

        public Boolean AddType(PageType type)
        {
            return _service.AddType(type);
        }
        public List<PageType> GetTypes()
        {
            return _service.GetTypes();
        }
        public Boolean DeActiveType(string id)
        {
           return _service.DeActiveType( id);

        }

        public Boolean ActiveType(string id)
        {
            return _service.ActiveType(id);

        }

    }
}
