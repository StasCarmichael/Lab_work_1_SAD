namespace BLL.DataFunctionalSubsystem.Interface
{
    public interface IPassport
    {
        string Name { get; }
        string Surname { get; }
        int Age { get; }
        string PassportNumber { get; }
    }
}
