using System.Text.RegularExpressions;

namespace BLL.RegExpressions
{
    public class RegEx
    {
        public static readonly Regex Name = new Regex("[a-zA-Zа-яА-ЯіїІЇйЙ]{1,100}");
        public static readonly Regex Surname = new Regex("[a-zA-Zа-яА-ЯіїІЇйЙ]{1,100}");

        public static bool Age(int age) { if (age >= 0 && age < 140) { return true; } else { return false; } }


        public static readonly Regex PassportNumber = new Regex("[0-9]{9}");
        public static readonly Regex IDCode = new Regex("[1-9]{1}[0-9]{9}");

    }
}
