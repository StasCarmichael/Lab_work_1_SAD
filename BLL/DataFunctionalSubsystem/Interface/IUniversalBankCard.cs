using System;
using BLL.ServiceInterface;

namespace BLL.DataFunctionalSubsystem.Interface
{
    public interface IUniversalBankCard : IAccount, ІІdІdentifier, IValidable
    {
        string BankName { get; }
        string BankCardNumber { get; }
        DateTime HowLongValid { get; }
    }
}
