using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            IPassport passport = passportService.CreatePassport("Stas", "Kyrei", 15, "983414365");

            Console.WriteLine(passport.Name);
            Console.WriteLine(passport.Surname);



            IDCodeBuilder iDCodeBuilder = IDCodeBuilder.GetUniqueIDBuilder("data.dat");

            List<IIDCode> iDCodes = new List<IIDCode>(100);

            for (int i = 0; i < 100; i++)
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
