using System.Linq;
using System.Web.Mvc;
using BookyBook.Business;
using BookyBook.Entity;

namespace BookyBook.MVC.Controllers
{
    public class AuthorController : Controller
    {
        BusinessBase<Author> busAuthor = new BusinessBase<Author>();


        public ActionResult Index()
        {
            var list = busAuthor.GetAll().OrderBy(x => x.Lastname).ToList();
            return View(list);
        }

        public ActionResult Kaydet(int id)
        {
            var entity = busAuthor.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Kaydet(Author mdl)
        {
            busAuthor.Save(mdl);

            return RedirectToAction("Index");
        }

    }
}