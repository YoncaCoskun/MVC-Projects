using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using BookyBook.Business;
using BookyBook.Entity;
using BookyBook.Entity.DTO;
using BookyBook.MVC.Helper;
using BookyBook.MVC.Models;

namespace BookyBook.MVC.Controllers
{
    public class RentTransactionController : Controller
    {
        BusinessBase<SearchResultDto> busSearch = new BusinessBase<SearchResultDto>();
        BusinessBase<Product> _busProduct = new BusinessBase<Product>();
        BusinessBase<Customer> _busCustomer = new BusinessBase<Customer>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            var product = _busProduct.GetById(id);

            var vmProd = new ViewModelProduct();
            vmProd.Name = product.Name;
            vmProd.Id = product.Id;
            vmProd.PageCount = product.PageCount;
            vmProd.PhotoPath = product.PhotoPath;
            vmProd.PlaceCode = product.PlaceCode;
            vmProd.Summary = product.Summary;

            //Book
            if (product is Book)
            {
                var book = product as Book;

                vmProd.ReleaseYear = book.ReleaseYear;
                vmProd.Language = book.Language.AttributeGetir().Name;

                vmProd.Authors = string.Join(", ", book.Authors.Select(x =>
                   x.Firstname + " " + x.Lastname
                ));

            }
            else if (product is Magazine)
            {
                var magazine = product as Magazine;
                vmProd.PublishDate = magazine.PublishDate;
                vmProd.PublishNumber = magazine.PublishNumber;
            }

            return View(vmProd);
        }

        public JsonResult GetBooksByType(string sonucTipi, int id)
        {
            var products = _busProduct.GetAll();

            if (sonucTipi == "Book" || sonucTipi == "Magazine")
            {
                products = products.Where(x => x.Id == id);
            }
            else if (sonucTipi == "Yazar")
            {
                products = products.OfType<Book>().Where(x => x.Authors.Any(y => y.Id == id));
            }
            else if (sonucTipi == "Yayin Evi")
            {
                products = products.OfType<Book>().Where(x => x.Publisher.Id == id);
            }

            var result = products.Select(x => new
            {
                x.Id,
                x.Name,
                x.PhotoPath
            }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Search(string keyword)
        {
            string sorgu = @"
SELECT Id, Name, Discriminator Type FROM Product
WHERE Name LIKE @keyword
	UNION
SELECT Id, Firstname + ' ' + Lastname, 'Yazar' FROM Author
WHERE Firstname LIKE @keyword OR Lastname LIKE @keyword
	UNION
SELECT Id, Name, 'Yayin Evi' FROM Publisher
WHERE Name LIKE @keyword";

            SqlParameter param = new SqlParameter("@keyword", SqlDbType.NVarChar);
            param.Value = "%" + keyword + "%";
            var result = busSearch.ExecuteSql(sorgu, param);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchMember(string keyword)
        {
            var uyeler = _busCustomer.GetAll()
                                         .Where(x =>
                                             x.Firstname.Contains(keyword) ||
                                             x.Lastname.Contains(keyword) ||
                                             x.TrIdentity.Contains(keyword) ||
                                             x.Mobile.Contains(keyword))
                                         .Select(x => new
                                         {
                                             x.Firstname,
                                             x.Lastname,
                                             x.TrIdentity,
                                             x.Mobile,
                                             x.Id
                                         }).ToList();

            return Json(uyeler, JsonRequestBehavior.AllowGet);
        }
    }
}