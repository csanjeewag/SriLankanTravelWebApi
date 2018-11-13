using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;

namespace EMS.Service
{
   public class PageService
    {
        private readonly EMS.Data.PageRepository _service;

        private readonly EMSContext _context;
        public PageService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.PageRepository(_context);
        }

        public Boolean AddPageDetails( PageDetail page)
        {
            return _service.CreatePage(page);
        }
        public Boolean UpdatePage(PageDetail page)

        {

           
                return _service.UpdatePages(page);
            

            
        }

        public Boolean AddImageName(List<string> imageNames, string id)
        {
            return _service.AddImageName(imageNames, id);
        }

        public PageDetail GetPage(string id)
        {
            return _service.GetPage(id);
        }
        public List<Images> GetImages(string id)
        {
            return _service.GetImages(id);
        }

        public List<Images> AllGetImages(string id)
        {
            return _service.AllGetImages(id);
        }

        public List<GetPageId> GetPages()
        {
            return _service.GetPages();
        }
        public List<AllGetPageId> AllGetPages()
        {
            return _service.AllGetPages();
        }
        public List<GetImageTopic> GetImageTopics()
        {
            return _service.GetImageTopics();
        }

        public Boolean DeActivePage(string id)
        {
            return _service.DeActivePage(id);
        }
        public Boolean ActivePage(string id)
        {
            return _service.ActivePage(id);
        }
        public Boolean DeActiveImage(string id)
        {
            return _service.DeActiveImage(id);
        }
        public Boolean ActiveImage(string id)
        {
            return _service.ActiveImage(id);
        }

        public Boolean SignUpUser(User user)
        {
            return _service.SignUpUser(user);
        }

        public Boolean LoginUser(User user)
        {
            return _service.LoginUser(user);
        }
    }
}
