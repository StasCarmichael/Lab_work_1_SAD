namespace BLL.DataFunctionalSubsystem.Interface
{
    public interface IAccount
    {
        bool PutMoney(decimal sum);
        bool WithdrawMoney(decimal sum);
    }
}
