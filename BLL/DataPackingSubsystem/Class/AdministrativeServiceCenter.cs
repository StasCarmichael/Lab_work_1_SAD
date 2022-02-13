using System;

using BLL.DataCreationSubsystem.Class;
using BLL.DataCreationSubsystem.Interface;
using BLL.DataElectronicCardSubsystem.Interface;
using BLL.DataElectronicCardSubsystem.Class;
using BLL.DataPackingSubsystem.Interface;

namespace BLL.DataPackingSubsystem.Class
{
    //Builder
    public class AdministrativeServiceCenter : IAdministrativeServiceCenter
    {
        #region Servise

        private UniversalElectronicCard UniversalElectronicCard;

        private IDCodeBuilder CodeBuilder;
        private IPassportService PassportService;


        #endregion


        public event EventHandler<string> MessageEvent;

        public AdministrativeServiceCenter(IDCodeBuilder codeBuilder, IPassportService passportService)
        {
            UniversalElectronicCard = null;

            CodeBuilder = codeBuilder;
            PassportService = passportService;
        }
        public AdministrativeServiceCenter(IDCodeBuilder codeBuilder, IPassportService passportService, IBank bank, IInsuranceAgency insuranceAgency)
          : this(codeBuilder, passportService)
        {
            Bank = bank;
            InsuranceAgency = insuranceAgency;
        }
        ~AdministrativeServiceCenter()
        {
            CodeBuilder.SaveChange();
        }



        public IBank Bank { get; set; }
        public IInsuranceAgency InsuranceAgency { get; set; }



        public void Reset()
        {
            UniversalElectronicCard = null;
        }

        public void CreateNewUserWithPassport(string name, string surname, DateTime age)
        {
            if (UniversalElectronicCard != null)
            {
                MessageEvent?.Invoke(this, "Новий користувач уже створений, повторного створеня не потребує.");
                return;
            }

            UniversalElectronicCard = new UniversalElectronicCard(CodeBuilder.GetUniqueID());
            UniversalElectronicCard.AddNewPassport(PassportService.CreatePassport(name, surname, age));

            MessageEvent?.Invoke(this, "Новий користувач успішно створений. Його паспорт також створений.");
        }

        public void AddBankCard()
        {
            try
            {
                if (UniversalElectronicCard == null)
                {
                    MessageEvent?.Invoke(this, "Спочатку потрібно створити об'єкт.");
                    return;
                }
                if (UniversalElectronicCard.HasBankCard)
                {
                    MessageEvent?.Invoke(this, "Банківська катра вже створена.");
                    return;
                }

                UniversalElectronicCard.AddNewBankCard(Bank.CreateUniversalBankCard(UniversalElectronicCard.IDCode));

                MessageEvent?.Invoke(this, "Банківська катра упішно створена");
            }
            catch (Exception)
            {
                MessageEvent?.Invoke(this, "Помилка при створені бінківської карти.");
            }
        }

        public void AddInsurancePolicy()
        {
            try
            {
                if (UniversalElectronicCard == null)
                {
                    MessageEvent?.Invoke(this, "Спочатку потрібно створити об'єкт.");
                    return;
                }
                if (!UniversalElectronicCard.HasBankCard)
                {
                    MessageEvent?.Invoke(this, "Спочатку потрібно створити банківську карту.");
                    return;
                }
                if (UniversalElectronicCard.HasInsurancePolicy)
                {
                    MessageEvent?.Invoke(this, "Страховий поліс вже створено.");
                    return;
                }

                UniversalElectronicCard.AddNewInsurancePolicy(InsuranceAgency.CreateUniversalInsurancePolicy(UniversalElectronicCard.IDCode, UniversalElectronicCard.BankCard));
            }
            catch (Exception)
            {
                MessageEvent?.Invoke(this, "Помилка при створені страхового полісу.");
            }

        }

        /// <summary>
        /// Когда возвращаем об'єкт то обєкт в памяти = null 
        /// </summary>
        /// <returns></returns>
        public IUniversalElectronicCard ReturnNewElectronicCard()
        {
            IUniversalElectronicCard electronicCard = UniversalElectronicCard;
            UniversalElectronicCard = null;
            return electronicCard;
        }


    }
}
