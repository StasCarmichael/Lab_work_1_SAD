using System;
using BLL.ServiceInterface;

namespace BLL.DataFunctionalSubsystem.Interface
{
    public interface IUniversalInsurancePolicy : ІІdІdentifier, IPayment, IValidable
    {
        decimal InsuranceCost { get; }
        DateTime HowLongValid { get; }

        bool Activate();
        decimal AmountOfInsuranceCoverage { get; }
    }
}
