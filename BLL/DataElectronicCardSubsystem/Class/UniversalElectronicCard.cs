using BLL.DataFunctionalSubsystem.Interface;
using BLL.DataCreationSubsystem.Interface;
using BLL.DataElectronicCardSubsystem.Interface;

namespace BLL.DataElectronicCardSubsystem.Class
{
    public class UniversalElectronicCard : IUniversalElectronicCard
    {
        public IIDCode IDCode { get; private set; }
        public string GetUniqueIdCode{ get { return IDCode?.GetUniqueIdCode ?? null; } }


        internal UniversalElectronicCard(IIDCode ID)
        {
            IDCode = ID;
        }


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
        public void AddNewPassport(IPassport passport)
        {
            if (passport != null) { Passport = passport; }
        }

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
            if (bankCard != null) { BankCard = bankCard; }
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
            if (insurancePolicy != null) { InsurancePolicy = insurancePolicy; }
        }

        #endregion


        public bool IsValid()
        {
            if (IDCode?.IsValid() == true && Passport?.IsValid() == true && BankCard?.IsValid() == true && InsurancePolicy?.IsValid() == true)
                return true;

            return false;
        }
    }
}
