using System.Collections.Generic;

namespace BookyBook.Entity
{
    public class Author: IEntityKey
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; } 

        public virtual ICollection<Book> Books { get; set; }
    }
}