using System;

using BLL.DataCreationSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Class;

namespace BLL.DataCreationSubsystem.Class
{
    public class UkrainianPassportService : IPassportService
    {
        public IPassport CreatePassport(string name, string surname, int age, string passportNumber)
        {
            UkrainianPassport ukrainianPassport = new UkrainianPassport();
            ukrainianPassport.Name = name;
            ukrainianPassport.Surname = surname;
            ukrainianPassport.Age = age;
            ukrainianPassport.PassportNumber = passportNumber;

            return ukrainianPassport;
        }
    }
}
