using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLL.DataCreationSubsystem.Class;
using BLL.DataCreationSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Class;

namespace Project
{

    class Program
    {
        static void Main(string[] args)
        {

            IPassportService passportService = new UkrainianPassportService();

            IPassport passport = passportService.CreatePassport("Stas", "Kyrei", new DateTime(2003,03,24));

            Console.WriteLine(passport.Name);
            Console.WriteLine(passport.Surname);



            IDCodeBuilder iDCodeBuilder = IDCodeBuilder.GetUniqueIDBuilder("data.dat");

            List<IIDCode> iDCodes = new List<IIDCode>(10);

            for (int i = 0; i < 10; i++)
            {
                iDCodes.Add(iDCodeBuilder.GetUniqueID());
            }

            foreach (var item in iDCodes)
            {
                Console.WriteLine(item.GetUniqueIdCode());
            }



        }
    }
}
