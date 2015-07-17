using System.ComponentModel.DataAnnotations;

namespace BookyBook.Entity.Enums
{
    public enum Gender
    {
        [Display(Name = "Erkek")]
        Male,
        [Display(Name = "Kadın")]
        Female
    }
}
