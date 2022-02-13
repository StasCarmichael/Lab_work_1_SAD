using System;
using System.Text.RegularExpressions;

namespace BLL.RegExpressions
{
    public class RegEx
    {
        public static readonly Regex Name = new Regex("[a-zA-Zа-яА-ЯіїІЇйЙ]{1,100}");
        public static readonly Regex Surname = new Regex("[a-zA-Zа-яА-ЯіїІЇйЙ]{1,100}");

        public static bool Age(DateTime age) { if (age.Year >= 1900 && age.Year < 2022) { return true; } else { return false; } }


        public static readonly Regex PassportNumber = new Regex("[0-9]{9}");
        public static readonly Regex IDCode = new Regex("[1-9]{1}[0-9]{9}");

    }
}
