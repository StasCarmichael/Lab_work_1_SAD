using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.DataFunctionalSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Class;

namespace Project
{

    class Program
    {
        static void Main(string[] args)
        {
            IPassportModify passport = new UkrainianPassport();
            passport.Name = "Stas";
            passport.Surname = "Kyrei";
            passport.PassportNumber = "FDKNH";
            passport.DateOfBirth = new DateTime(2003, 3, 15);

            IPassport passport1 = passport as IPassport;
            Console.WriteLine(passport1.Name);
            Console.WriteLine(passport1.Surname);
        }
    }
}
