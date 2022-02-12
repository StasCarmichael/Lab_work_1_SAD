using BLL.DataFunctionalSubsystem.Interface;

namespace BLL.DataCreationSubsystem.Interface
{
    public interface IBank
    {
        IUniversalBankCard CreateUniversalBankCard(IIDCode owner);
        IUniversalBankCard CreateUniversalBankCard(IIDCode owner, decimal sum);
    }
}
