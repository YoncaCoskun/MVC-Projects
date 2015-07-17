using System;

namespace BookyBook.Entity
{
    public class Magazine : Product
    {
        public int PublishNumber { get; set; }
        public DateTime PublishDate { get; set; }
    }
}