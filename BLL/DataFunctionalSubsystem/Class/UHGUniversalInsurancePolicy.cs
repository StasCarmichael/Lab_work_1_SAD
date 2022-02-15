using System;
using BLL.DataFunctionalSubsystem.Interface;

namespace BLL.DataFunctionalSubsystem.Class
{
    public class UHGUniversalInsurancePolicy : IUniversalInsurancePolicy
    {
        const decimal COST = 500;
        const decimal MAX_INSURANCE_COVERAGE = 100000;

        const int VALID_TIME = 1;
        const int FIRST_DAY = 1;


        internal UHGUniversalInsurancePolicy(IIDCode owner, IUniversalBankCard paymentMethod)
            : base()
        {
            HowLongValid = DateTime.MinValue;
            OwnerCode = null;
            InsuranceCost = COST;
            AmountOfInsuranceCoverage = 0;


            OwnerCode = owner;
            PaymentMethod = paymentMethod;
        }


        public IIDCode OwnerCode { get; internal set; }
        public IUniversalBankCard PaymentMethod { get; internal set; }

        public decimal InsuranceCost { get; private set; }
        public DateTime HowLongValid { get; internal set; }


        public decimal AmountOfInsuranceCoverage { get; private set; }
        public bool Activate()
        {
            if (OwnerCode != null && PaymentMethod != null)
            {
                if (PaymentMethod.CurrentSum > InsuranceCost)
                {
                    PaymentMethod.WithdrawMoney(InsuranceCost);
                    AmountOfInsuranceCoverage = MAX_INSURANCE_COVERAGE;
                    HowLongValid = new DateTime(DateTime.Now.Year + VALID_TIME, DateTime.Now.Month, FIRST_DAY);

                    return true;
                }
            }

            return false;
        }


        public bool IsActivated
        {
            get
            {
                if (AmountOfInsuranceCoverage == MAX_INSURANCE_COVERAGE) { return true; }
                return false;
            }
        }


        public bool IsValid()
        {
            if (OwnerCode != null && PaymentMethod != null)
                if (HowLongValid.Year <= DateTime.Now.Year && HowLongValid.Month <= DateTime.Now.Month)
                    return true;

            return false;
        }
    }
}
