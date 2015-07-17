using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;
using BookyBook.Business;
using BookyBook.Entity;
using BookyBook.Entity.Enums;
using BookyBook.MVC.Helper;

namespace BookyBook.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        BusinessBase<Employee> busEmployee = new BusinessBase<Employee>();


        public ActionResult Index()
        {
            var list = busEmployee.GetAll().OrderBy(x => x.Lastname).ToList();
            return View(list);
        }

        public ActionResult Kaydet(int id)
        {
            var entity = busEmployee.GetById(id);

            return View(entity);
        }

        [HttpPost]
        public ActionResult Kaydet(Employee mdl)
        {
            busEmployee.Save(mdl);

            return RedirectToAction("Index");
        }

    }
}