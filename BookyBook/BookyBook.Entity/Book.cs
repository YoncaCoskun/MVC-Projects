using System.Collections.Generic;
using BookyBook.Entity.Enums;

namespace BookyBook.Entity
{
    public class Book : Product
    {
        public Language Language { get; set; }
        public int ReleaseYear { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}