namespace BLL.DataElectronicCardSubsystem.Interface
{
    public interface IBankData
    {
        string BankCardNumber { get; }
        decimal CurrentSum { get; }
    }
}
