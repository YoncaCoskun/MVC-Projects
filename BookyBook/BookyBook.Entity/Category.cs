using System.Collections.Generic;

namespace BookyBook.Entity
{
    public class Category : IEntityKey
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}