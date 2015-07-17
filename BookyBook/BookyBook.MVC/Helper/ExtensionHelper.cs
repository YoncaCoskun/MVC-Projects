using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BookyBook.MVC.Helper
{
    public static class ExtensionHelper
    {
        public static string Capitalize(this string value)
        {
            string lower = value.ToLower();
            string firstChar = value.Substring(0, 1).ToUpper();

            return firstChar + lower.Substring(1);
        }


        public static DisplayAttribute AttributeGetir(this Enum enumValue)
        {
            return enumValue
                .GetType()
                .GetMember(enumValue.ToString()) 
                .First()
                .GetCustomAttribute<DisplayAttribute>();

        }
    }
}
