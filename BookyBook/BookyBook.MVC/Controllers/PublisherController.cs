using System.Linq;
using System.Web.Mvc;
using BookyBook.Business;
using BookyBook.Entity;

namespace BookyBook.MVC.Controllers
{
    public class PublisherController : Controller
    {
        BusinessBase<Publisher> busPublisher = new BusinessBase<Publisher>();


        public ActionResult Index()
        {
            var list = busPublisher.GetAll().OrderBy(x => x.Name).ToList();
            return View(list);
        }

        public ActionResult Kaydet(int id)
        {
            var entity = busPublisher.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Kaydet(Publisher mdl)
        {
            busPublisher.Save(mdl);

            return RedirectToAction("Index");
        }

    }
}