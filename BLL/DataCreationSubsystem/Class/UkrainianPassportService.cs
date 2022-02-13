using System;

using BLL.DataCreationSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Class;

namespace BLL.DataCreationSubsystem.Class
{
    public class UkrainianPassportService : IPassportService
    {
        private const int SIZE = 9;
        private const int MAX_INDEX = 10;
        private const int MIN_FIRST_INDEX = 0;

        private string CreatePassportNumber()
        {
            Random random = new Random();
            string code = string.Empty;

            for (int i = 0; i < SIZE; i++)
                code += random.Next(MIN_FIRST_INDEX, MAX_INDEX);
            
            return code;
        }

        public IPassport CreatePassport(string name, string surname, DateTime age)
        {
            UkrainianPassport ukrainianPassport = new UkrainianPassport();
            ukrainianPassport.Name = name;
            ukrainianPassport.Surname = surname;
            ukrainianPassport.Age = age;
            ukrainianPassport.PassportNumber = CreatePassportNumber();

            return ukrainianPassport;
        }
    }
}
