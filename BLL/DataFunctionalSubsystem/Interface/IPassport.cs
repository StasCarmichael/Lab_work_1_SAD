using System;

namespace BLL.DataFunctionalSubsystem.Interface
{
    public interface IPassport
    {
        string Name { get; }
        string Surname { get; }
        DateTime Age { get; }
        string PassportNumber { get; }
    }
}
