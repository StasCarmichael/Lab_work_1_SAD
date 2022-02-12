using BLL.DataFunctionalSubsystem.Interface;

namespace BLL.DataCreationSubsystem.Interface
{
    public interface IInsuranceAgency
    {
        IUniversalInsurancePolicy CreateUniversalInsurancePolicy(IIDCode owner, IUniversalBankCard paymentMethod);
    }
}
