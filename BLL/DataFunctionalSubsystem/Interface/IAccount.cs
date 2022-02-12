namespace BLL.DataFunctionalSubsystem.Interface
{
    public interface IAccount
    {
        decimal CurrentSum { get; }
        bool PutMoney(decimal sum);
        bool WithdrawMoney(decimal sum);
    }
}
