using System;

namespace BLL.DataFunctionalSubsystem.Interface
{
    public interface IUniversalBankCard : IAccount, ІІdІdentifier
    {
        string BankName { get; }
        string BankCardNumber { get; }
        DateTime HowLongValid { get; }
    }
}
