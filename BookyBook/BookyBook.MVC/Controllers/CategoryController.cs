using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookyBook.Business;
using BookyBook.Entity;

namespace BookyBook.MVC.Controllers
{
    public class CategoryController : Controller
    {
        BusinessBase<Category> busCategory = new BusinessBase<Category>();


        public ActionResult Index()
        {
            var cats = busCategory.GetAll().OrderBy(x => x.Name).ToList();
            return View(cats);
        }

        public ActionResult Kaydet(int id)
        {
            var category = busCategory.GetById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Kaydet(Category mdl)
        {
            busCategory.Save(mdl);

            return RedirectToAction("Index");
        }

    }
}