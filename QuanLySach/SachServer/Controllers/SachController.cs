using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SachServer.Controllers
{
    public class SachController : ApiController
    {
        
        [HttpGet]
        public List<Sach> GetSachLists()
        {
            dbBookDataContext db = new dbBookDataContext();
            return db.Saches.ToList();
        }

        [HttpGet]
        public Sach GetSach(int id)
        {
            dbBookDataContext db = new dbBookDataContext();
            return db.Saches.FirstOrDefault(x => x.Id == id);
        }

       
        [HttpPost]
        public bool InsertNewSach(string title, string content, string author, int price)
        {
            try
            {
                dbBookDataContext db = new dbBookDataContext();
                Sach sach = new Sach();
                sach.Title = title;
                sach.Content = content;
                sach.AuthorName = author;
                sach.Price = price;
                db.Saches.InsertOnSubmit(sach);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        [HttpPut]
        public bool UpdateSach(int id, string title, string content, string author, int price)
        {

            try
            {
                dbBookDataContext db = new dbBookDataContext();
                Sach sach = db.Saches.FirstOrDefault(x => x.Id == id);
                if (sach == null) return false;
                sach.Title = title;
                sach.Content = content;
                sach.AuthorName = author;
                sach.Price = price;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

       
        [HttpDelete]
        public bool DeleteSach(int id)
        {
            dbBookDataContext db = new dbBookDataContext();
            Sach sach = db.Saches.FirstOrDefault(x => x.Id == id);
            if (sach == null) return false;
            db.Saches.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return true;
        }
    }
}
