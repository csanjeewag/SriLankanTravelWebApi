using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;

namespace EMS.Data
{
    public class PageRepository
    {
        private readonly EMSContext _context;
        public PageRepository(EMSContext context)
        {
            _context = context;
        }

        public Boolean CreatePage(PageDetail page)
        {
            try
            {
                DateTime today = DateTime.Today;
                page.StartDate = today;
                page.IsActive = true;
                page.Id = DateTime.Now.ToString("yymmssfff");
                _context.PageDetails.Add(page);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Boolean UpdatePages(PageDetail page)
        {
            if (page.DefImage == "" || page.DefImage == null)
            {
                var text = _context.PageDetails
               .Where(p => p.Id == page.Id)
               .Select(p => p.DefImage)
                .FirstOrDefault();

                page.DefImage = text;
            }
            var author = _context.PageDetails
               .Where(p => p.Id == page.Id)
               .Select(p => p.UsersEmail)
                .FirstOrDefault();
            page.UsersEmail = author;

            return UpdatePage(page);
        }

        public Boolean UpdatePage(PageDetail page)
        {
            try
            {


                _context.Entry(page).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }


        public Boolean AddImageName(List<string> imageNames, string id)
        {

            foreach (var imageName in imageNames)
            {

                DateTime today = DateTime.Today;
                Images image = new Images();
                image.ImageId = imageName;
                image.PageDetailsId = id;
                image.IsActive = true;
                image.StartDate = today;
                _context.Images.Add(image);
                _context.SaveChanges();
            }
            return true;

        }



        public PageDetail GetPage(string id)
        {


            var test = _context.PageDetails
                  .Where(c => c.IsActive == true)
                  .Where(c => c.Id == id)
                   .FirstOrDefault();
            var name = _context.Users.Where(c => c.Email == test.UsersEmail).Select(c => new { fname=c.Fname , lname = c.Lname}).FirstOrDefault();
            test.UsersEmail = name.fname+" "+ name.lname;
            return test;

        }
        public PageDetail DeGetPage(string id)
        {
           
            var test = _context.PageDetails
                  .Where(c => c.Id == id)
                   .FirstOrDefault();
            return test;

        }

        public List<GetPageId> GetPages()
        {
            var test = _context.PageDetails
                  .Where(c => c.IsActive == true)
                  .Select(p => new GetPageId { Id = p.Id, Topic = p.Topic })
                 .ToList();
            return test;

        }

        public List<AllGetPageId> AllGetPages()
        {
            
            var test = _context.PageDetails
                  .Select(p => new AllGetPageId { Id = p.Id, Topic = p.Topic, ImageId = p.DefImage, IsActive = p.IsActive, StartDate = p.StartDate, Type = p.Type, SubTopic = p.SubTopic, Author = p.UsersEmail })
                 .ToList();
            return test;

        }

        public List<Images> GetImages(string id)
        {
            var test = _context.Images
                  .Where(c => c.IsActive == true)
                  .Where(c => c.PageDetailsId == id)
                   .ToList();

            return test;
        }
        public List<Images> AllGetImages(string id)
        {
            var test = _context.Images
                  .Where(c => c.PageDetailsId == id)
                   .ToList();

            return test;
        }
        public List<GetImageTopic> GetImageTopics()
        {
            var test = _context.PageDetails
                  .Where(c => c.IsActive == true)
                  .Select(p => new GetImageTopic { Id = p.Id, Topic = p.Topic, ImageId = p.DefImage, Type = p.Type, SubTopic = p.SubTopic , District=p.District, Town=p.Town})
                 .ToList();
            return test;
        }

        public Boolean DeActivePage(string id)
        {

            PageDetail page = new PageDetail();
            page = this.DeGetPage(id);
            page.IsActive = false;
            if (UpdatePage(page))
            {
                return true;
            }
            return false;
        }
        public Boolean ActivePage(string id)
        {
            PageDetail page = new PageDetail();
            page = this.DeGetPage(id);
            page.IsActive = true;
            if (UpdatePage(page))
            {
                return true;
            }
            return false;
        }

        public Boolean DeActiveImage(string id)
        {
            var Id = id;
            try
            {
                Images image = new Images();
                var s = _context.Images
                      .Where(c => c.IsActive == true)
                      .Where(c => c.ImageId == Id)
                      .FirstOrDefault();

                image = s;
                image.IsActive = false;
                _context.Entry(image).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }


        }
        public Boolean ActiveImage(string id)
        {
            var Id = id;
            try
            {
                Images image = new Images();
                var s = _context.Images
                      .Where(c => c.IsActive == false)
                      .Where(c => c.ImageId == Id)
                      .FirstOrDefault();

                image = s;
                image.IsActive = true;
                _context.Entry(image).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }


        }

    } 
}
