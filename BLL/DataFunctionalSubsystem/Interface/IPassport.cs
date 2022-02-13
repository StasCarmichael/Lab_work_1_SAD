using System;
using BLL.ServiceInterface;

namespace BLL.DataFunctionalSubsystem.Interface
{
    public interface IPassport : IValidable
    {
        string Name { get; }
        string Surname { get; }
        DateTime Age { get; }
        string PassportNumber { get; }
    }
}
