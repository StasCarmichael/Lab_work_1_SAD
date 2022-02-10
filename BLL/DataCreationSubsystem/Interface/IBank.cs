using System;


using BLL.DataFunctionalSubsystem.Class;
using BLL.DataFunctionalSubsystem.Interface;

namespace BLL.DataCreationSubsystem.Interface
{
    public interface IBank
    {
        IUniversalBankCard CreateUniversalBankCard();
    }
}
