using System.Linq;
using System.Web.Mvc;
using BookyBook.Business;
using BookyBook.Entity;

namespace BookyBook.MVC.Controllers
{
    public class CustomerController : Controller
    {
        BusinessBase<Customer> busCustomer = new BusinessBase<Customer>();


        public ActionResult Index()
        {
            var list = busCustomer.GetAll()
                .OrderBy(x => x.Lastname)
                .ThenBy(x=>x.Firstname)
                .ToList();
            return View(list);
        }

        public ActionResult Kaydet(int id)
        {
            var entity = busCustomer.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Kaydet(Customer mdl)
        {
            busCustomer.Save(mdl);

            return RedirectToAction("Index");
        }

    }
}