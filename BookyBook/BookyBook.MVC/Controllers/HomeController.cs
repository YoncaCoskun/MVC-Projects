using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookyBook.Business;
using BookyBook.Entity;

namespace BookyBook.MVC.Controllers
{
    public class HomeController : Controller
    {
        BusinessBase<Author> businessAuthor = new BusinessBase<Author>();
        // GET: Home
        public ActionResult Index()
        {
            var all = businessAuthor.GetAll().ToList();
            return View();
        }
    }
}