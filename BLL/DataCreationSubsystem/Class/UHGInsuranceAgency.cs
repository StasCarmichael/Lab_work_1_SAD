using System;

using BLL.DataCreationSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Class;

namespace BLL.DataCreationSubsystem.Class
{
    public class UHGInsuranceAgency : IInsuranceAgency
    {
        public IUniversalInsurancePolicy CreateUniversalInsurancePolicy(IIDCode owner, IUniversalBankCard paymentMethod)
        {
            UHGUniversalInsurancePolicy insurancePolicy = new UHGUniversalInsurancePolicy(owner, paymentMethod);

            return insurancePolicy;
        }
    }
}
