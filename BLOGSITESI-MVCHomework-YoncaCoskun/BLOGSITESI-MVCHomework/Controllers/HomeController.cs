using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLOGSITESI_MVCHomework.Models;

namespace BLOGSITESI_MVCHomework.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult AdminMakaleListele()
        {
            BlogSitesiEntities context=new BlogSitesiEntities();

            var makaleler = context.Makale.Select(x => new BlogModel
            {
                MakaleId = x.MakaleId,
                Baslik = x.MakaleBaslik,
               Ozet = x.MakaleOzet,
               Icerik = x.MakaleIcerik

            });

            return View(makaleler);
        }


        public ActionResult Gor(int id)
        {
            if (id>0)
            {
                using (BlogSitesiEntities context=new BlogSitesiEntities())
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
                            EklenmeTarihi = (DateTime) makale.EklenmeTarihi
                        };
                        return View(model);
                    }
                }
            }
            return View();
        }

        

        public ActionResult Kaydet(BlogModel model)
        {
            using (BlogSitesiEntities context = new BlogSitesiEntities())
            {
                Makale mkl;
                if (model.MakaleId > 0)
                {
                    //guncelle

                  mkl = context.Makale.Find(model.MakaleId);

                }
                else
                {
                    //ekle
                   mkl=new Makale();
                    context.Makale.Add(mkl);


                }
                mkl.EklenmeTarihi = model.EklenmeTarihi;
                mkl.MakaleBaslik = model.Baslik.Trim();
                mkl.MakaleIcerik = model.Icerik.Trim();
                mkl.MakaleOzet = model.Ozet.Trim();
                mkl.OkunmaSayisi = model.OkumaSayisi.Trim();

                context.SaveChanges();
            }
            return RedirectToAction("AdminMakaleListele");
        }

        public ActionResult Sil(int id)
        {
            using (BlogSitesiEntities context=new BlogSitesiEntities())
            {
                Makale mkl = context.Makale.Find(id);
                context.Makale.Remove(mkl);
                context.SaveChanges();
            }
            return RedirectToAction("AdminMakaleListele");
        }

        public ActionResult UserMakaleListele()
        {
            BlogSitesiEntities context = new BlogSitesiEntities();

            var makaleler = context.Makale.Select(x => new BlogModel
            {
                MakaleId = x.MakaleId,
                Baslik = x.MakaleBaslik,
                Ozet = x.MakaleOzet,
                Icerik = x.MakaleIcerik

            });

            return View(makaleler);
        }

        public ActionResult MakaleDetay(int id)
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