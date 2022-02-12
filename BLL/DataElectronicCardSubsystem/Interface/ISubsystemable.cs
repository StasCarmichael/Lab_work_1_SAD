using BLL.DataFunctionalSubsystem.Interface;

namespace BLL.DataElectronicCardSubsystem.Interface
{
    public interface ISubsystemable
    {
        IPassport Passport { get; }

        IUniversalBankCard BankCard { get; }

        IUniversalInsurancePolicy InsurancePolicy { get; }
    }
}
