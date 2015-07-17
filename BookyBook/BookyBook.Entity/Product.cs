using System.Collections.Generic;

namespace BookyBook.Entity
{
    public class Product : IEntityKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string PlaceCode { get; set; }
        public string Summary { get; set; }
        public string PhotoPath { get; set; }


        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
