using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLOGSITESI_MVCHomework.Models
{
    public class BlogModel
    {
        public int MakaleId { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Icerik { get; set; }
        public string OkumaSayisi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
    }
}