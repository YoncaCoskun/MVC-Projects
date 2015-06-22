using System;
using System.Web.Mvc;
using BLOGSITESI_MVCHomework.Models;

namespace BLOGSITESI_MVCHomework.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Guncelle(int id)
        {
            if (id > 0)
            {
                using (BlogSitesiEntities context = new BlogSitesiEntities())
                {
                    Makale makale = context.Makale.Find(id);

                    if (makale.EklenmeTarihi != null)
                    {
                        BlogModel model = new BlogModel
                        {
                            MakaleId = makale.MakaleId,
                            Baslik = makale.MakaleBaslik,
                            Ozet = makale.MakaleOzet,
                            Icerik = makale.MakaleIcerik,
                            OkumaSayisi = makale.OkunmaSayisi,
                            EklenmeTarihi = (DateTime)makale.EklenmeTarihi
                        };
                        return View(model);
                    }
                }
            }
            return View();
        }
    }
}