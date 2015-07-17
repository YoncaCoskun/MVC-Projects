using System;

namespace BookyBook.Entity
{
    public class RentTransaction : IEntityKey
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; } 
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
    }
}