using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookyBook.Business;
using BookyBook.Entity;

namespace BookyBook.MVC.Controllers
{
    public class BookController : Controller
    {
        BusinessBase<Book> busBook = new BusinessBase<Book>();
        BusinessBase<Publisher> busPublisher = new BusinessBase<Publisher>();


        public ActionResult Index()
        {
            var list = busBook.GetAll().OrderBy(x => x.Name).ToList();
            return View(list);
        }

        public ActionResult Kaydet(int id)
        {
            var yayinEvleri = busPublisher.GetAll().Select(
                                            x => new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.Id.ToString()
                                            }).ToList();

            ViewBag.TumYayinEvleri = yayinEvleri;

            var entity = busBook.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Kaydet(Book mdl, HttpPostedFileBase fileUpload1)
        {
            // dosya boyut kontrolü
            //  fileUpload1.ContentLength>154200

            busBook.Save(mdl);

            string path =ConfigurationManager.AppSettings["FileSavePath"];
            //string uzanti = Path.GetExtension(fileUpload1.FileName);
            string fileName = String.Format("{0}.png", mdl.Id); ;

            if (!Directory.Exists(Server.MapPath(path)))
                Directory.CreateDirectory(Server.MapPath(path));

            string fullPath = Path.Combine(path, fileName);

            fileUpload1.SaveAs(Server.MapPath(fullPath));

            mdl.PhotoPath = fullPath;
            busBook.Save(mdl);

            return RedirectToAction("Index");
        }

    }
}