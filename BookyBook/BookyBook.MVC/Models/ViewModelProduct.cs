using System;

namespace BookyBook.MVC.Models
{
    public class ViewModelProduct
    {
        //Product
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string PlaceCode { get; set; }
        public string PhotoPath { get; set; }
        public string Summary { get; set; }

        //Book
        public string Language { private get; set; }
        public int? ReleaseYear { private get; set; }
        public string Authors { private get; set; }

        public string LanguageWithTitle
        {
            get
            {
                if (string.IsNullOrEmpty(Language))
                    return String.Empty;
                return string.Format("Dil:{0} ", Language);
            }
        }
        public string ReleaseYearWithTitle
        {
            get
            {
                if (!ReleaseYear.HasValue)
                    return String.Empty;
                return string.Format("Yayın Yılı:{0} ", ReleaseYear);
            }
        }
        public string AuthorsWithTitle
        {
            get
            {
                if (string.IsNullOrEmpty(Authors))
                    return String.Empty;
                return string.Format("Yazarlar:{0} ", Authors);
            }
        }


        //Magazine
        public int? PublishNumber { private get; set; }
        public DateTime? PublishDate { private get; set; }

        public string PublishNumberWithTitle
        {
            get
            {
                if (PublishNumber == null)
                    return String.Empty;
                return string.Format("Yayın No:{0} ", PublishNumber);
            }
        }

        public string PublishDateWithTitle
        {
            get
            {
                if (PublishDate == null)
                    return String.Empty;
                return string.Format("Yayın Tarihi:{0} ", PublishDate);
            }
        }
    }
}