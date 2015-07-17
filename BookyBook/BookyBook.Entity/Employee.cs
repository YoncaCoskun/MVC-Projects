using BookyBook.Entity.Enums;

namespace BookyBook.Entity
{
    public class Employee : IEntityKey
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; } 
    }
}