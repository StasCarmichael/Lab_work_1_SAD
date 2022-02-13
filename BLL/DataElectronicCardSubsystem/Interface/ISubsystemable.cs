using BLL.DataFunctionalSubsystem.Interface;

namespace BLL.DataElectronicCardSubsystem.Interface
{
    public interface ISubsystemable
    {
        IPassport Passport { get; }
        bool HasPassport { get; }
        void AddNewPassport(IPassport passport);


        IUniversalBankCard BankCard { get; }
        bool HasBankCard { get; }
        void AddNewBankCard(IUniversalBankCard bankCard);


        IUniversalInsurancePolicy InsurancePolicy { get; }
        bool HasInsurancePolicy { get; }
        void AddNewInsurancePolicy(IUniversalInsurancePolicy insurancePolicy);
    }
}
