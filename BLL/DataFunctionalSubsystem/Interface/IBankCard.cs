using System;

namespace BLL.DataFunctionalSubsystem.Interface
{
    public interface IBankCard
    {

        string BankName { get; }
        string BankCardNumber { get; }
        DateTime HowLongValid { get; }
    }
}
