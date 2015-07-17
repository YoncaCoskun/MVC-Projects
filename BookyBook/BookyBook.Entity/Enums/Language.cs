using System.ComponentModel.DataAnnotations;

namespace BookyBook.Entity.Enums
{
    public enum Language
    {
        [Display(Name = "İngilizce")]
        English,
        [Display(Name = "Türkçe")]
        Turkce,
        [Display(Name = "Almanca")]
        Deutsch
    }
}
