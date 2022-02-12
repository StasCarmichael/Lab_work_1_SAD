namespace BLL.DataFunctionalSubsystem.Interface
{
    public interface IPayment
    {
        IUniversalBankCard PaymentMethod { get; }
    }
}
