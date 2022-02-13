using System;

using BLL.DataFunctionalSubsystem.Interface;
using BLL.DataCreationSubsystem.Interface;
using BLL.DataElectronicCardSubsystem.Interface;

namespace BLL.DataElectronicCardSubsystem.Class
{
    class UniversalElectronicCard : IUniversalElectronicCard
    {
        private IIDCode iDCode;

        internal UniversalElectronicCard(IIDCode ID)
        {
            iDCode = ID;
        }

        public string GetUniqueIdCode() { return iDCode?.GetUniqueIdCode() ?? null; }


        #region Pasport

        public string Name
        {
            get { return Passport?.Name ?? null; }
        }
        public string Surname
        {
            get { return Passport?.Surname ?? null; }
        }

        public IPassport Passport { get; private set; }
        public bool HasPassport
        {
            get
            {
                if (Passport != null) { return true; }
                return false;
            }
        }
        public void AddNewPassport(IPassport passport) { Passport = passport; }

        #endregion


        #region BankCard

        public string BankCardNumber
        {
            get { return BankCard?.BankCardNumber ?? null; }
        }
        public decimal CurrentSum
        {
            get { return BankCard?.CurrentSum ?? decimal.Zero; }
        }

        public IUniversalBankCard BankCard { get; private set; }
        public bool HasBankCard
        {
            get
            {
                if (BankCard != null) { return true; }
                return false;
            }
        }
        public void AddNewBankCard(IUniversalBankCard bankCard)
        {
            BankCard = bankCard;
        }

        #endregion


        #region InsurancePolicy

        public IUniversalInsurancePolicy InsurancePolicy { get; private set; }
        public bool HasInsurancePolicy
        {
            get
            {
                if (InsurancePolicy != null) { return true; }
                return false;
            }
        }
        public void AddNewInsurancePolicy(IUniversalInsurancePolicy insurancePolicy)
        {
            InsurancePolicy = insurancePolicy;
        }

        #endregion
    }
}
