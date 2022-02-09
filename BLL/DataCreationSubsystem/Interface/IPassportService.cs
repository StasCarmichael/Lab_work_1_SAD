using BLL.DataFunctionalSubsystem.Interface;

namespace BLL.DataCreationSubsystem.Interface
{
    public interface IPassportService
    {
        IPassport CreatePassport(string name, string surname, int age, string passportNumber);
    }
}
