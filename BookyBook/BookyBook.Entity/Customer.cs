using System;
using BookyBook.Entity.Enums;

namespace BookyBook.Entity
{
    public class Customer : IEntityKey
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }
        public string TrIdentity { get; set; }
        public Gender Gender { get; set; } 
    }
}