using System;
using Xunit;

using BLL.DataCreationSubsystem.Class;
using BLL.DataCreationSubsystem.Interface;
using BLL.DataElectronicCardSubsystem.Interface;
using BLL.DataElectronicCardSubsystem.Class;
using BLL.DataPackingSubsystem.Interface;
using BLL.DataPackingSubsystem.Class;


namespace Test
{
    public class IntegrationTestingDataPackingSys
    {

        [Fact]
        public void TestIsValid()
        {
            IDCodeBuilder iDCodeBuilder = IDCodeBuilder.GetUniqueIDBuilder("data.dat");

            AdministrativeServiceCenter serviceCenter = new AdministrativeServiceCenter(iDCodeBuilder, new UkrainianPassportService());

            serviceCenter.Bank = new MonoBank();
            serviceCenter.InsuranceAgency = new UHGInsuranceAgency();

            serviceCenter.Reset();

            serviceCenter.CreateNewUserWithPassport("Stas", "Kirey", new DateTime(2003, 5, 23));
            serviceCenter.AddBankCard();
            serviceCenter.AddInsurancePolicy();

            IUniversalElectronicCard elestronicCard = serviceCenter.ReturnNewElectronicCard();

            iDCodeBuilder.SaveChange();

            Assert.False(elestronicCard.IsValid());
        }


        [Fact]
        public void TestPassport()
        {
            string name = "Stas";
            string surname = "Kyrei";

            IDCodeBuilder iDCodeBuilder = IDCodeBuilder.GetUniqueIDBuilder("data.dat");

            AdministrativeServiceCenter serviceCenter = new AdministrativeServiceCenter(iDCodeBuilder, new UkrainianPassportService());

            serviceCenter.Bank = new MonoBank();
            serviceCenter.InsuranceAgency = new UHGInsuranceAgency();

            serviceCenter.Reset();

            serviceCenter.CreateNewUserWithPassport(name, surname, new DateTime(2003, 5, 23));
            serviceCenter.AddBankCard();
            serviceCenter.AddInsurancePolicy();

            IUniversalElectronicCard elestronicCard = serviceCenter.ReturnNewElectronicCard();

            if (elestronicCard.Name == name && elestronicCard.Surname == surname)
            {
                Assert.True(true);
            }
        }


        [Fact]
        public void TestInsurancePolicy()
        {
            decimal MAX_SUM = 100000;

            IDCodeBuilder iDCodeBuilder = IDCodeBuilder.GetUniqueIDBuilder("data.dat");

            AdministrativeServiceCenter serviceCenter = new AdministrativeServiceCenter(iDCodeBuilder, new UkrainianPassportService());

            serviceCenter.Bank = new MonoBank();
            serviceCenter.InsuranceAgency = new UHGInsuranceAgency();

            serviceCenter.Reset();

            serviceCenter.CreateNewUserWithPassport("Stas", "Kirey", new DateTime(2003, 5, 23));
            serviceCenter.AddInsurancePolicy();
            serviceCenter.AddBankCard();
            serviceCenter.AddInsurancePolicy();

            var elestronicCard = serviceCenter.ReturnNewElectronicCard();
            elestronicCard.BankCard.PutMoney(3000);
            elestronicCard.InsurancePolicy.Activate();


            Assert.Equal(elestronicCard.InsurancePolicy.AmountOfInsuranceCoverage, MAX_SUM);
        }



        #region BankTest

        [Fact]
        public void TestMonoBankAction()
        {
            decimal money = 2000;

            IDCodeBuilder iDCodeBuilder = IDCodeBuilder.GetUniqueIDBuilder("data.dat");

            AdministrativeServiceCenter serviceCenter = new AdministrativeServiceCenter(iDCodeBuilder, new UkrainianPassportService());

            serviceCenter.Bank = new MonoBank();
            serviceCenter.InsuranceAgency = new UHGInsuranceAgency();

            serviceCenter.Reset();

            serviceCenter.CreateNewUserWithPassport("Stas", "Kirey", new DateTime(2003, 5, 23));
            serviceCenter.AddBankCard();
            serviceCenter.CreateNewUserWithPassport("Stas", "Kirey", new DateTime(2003, 5, 23));

            var elestronicCard = serviceCenter.ReturnNewElectronicCard();


            elestronicCard.BankCard.PutMoney(3000);
            elestronicCard.BankCard.WithdrawMoney(1000);

            Assert.Equal(elestronicCard.BankCard.CurrentSum, money);
        }

        [Fact]
        public void TestPrivateBankAction()
        {
            decimal money = 2000;

            IDCodeBuilder iDCodeBuilder = IDCodeBuilder.GetUniqueIDBuilder("data.dat");

            AdministrativeServiceCenter serviceCenter = new AdministrativeServiceCenter(iDCodeBuilder, new UkrainianPassportService());

            serviceCenter.Bank = new PrivateBank();
            serviceCenter.InsuranceAgency = new UHGInsuranceAgency();

            serviceCenter.Reset();

            serviceCenter.CreateNewUserWithPassport("Stas", "Kirey", new DateTime(2003, 5, 23));
            serviceCenter.AddBankCard();

            var elestronicCard = serviceCenter.ReturnNewElectronicCard();

            elestronicCard.BankCard.PutMoney(3000);
            elestronicCard.BankCard.WithdrawMoney(1000);

            Assert.Equal(elestronicCard.BankCard.CurrentSum, money);
        }

        [Fact]
        public void TestMonoBankCreateInElectronicCard()
        {
            decimal money = 10000;

            IDCodeBuilder iDCodeBuilder = IDCodeBuilder.GetUniqueIDBuilder("data.dat");

            AdministrativeServiceCenter serviceCenter = new AdministrativeServiceCenter(iDCodeBuilder, new UkrainianPassportService());

            serviceCenter.Bank = new PrivateBank();
            serviceCenter.InsuranceAgency = new UHGInsuranceAgency();

            serviceCenter.Reset();

            serviceCenter.CreateNewUserWithPassport("Stas", "Kirey", new DateTime(2003, 5, 23));
            serviceCenter.AddBankCard();

            var elestronicCard = serviceCenter.ReturnNewElectronicCard();


            elestronicCard.AddNewBankCard(new MonoBank().CreateUniversalBankCard(elestronicCard.IDCode, money));

            Assert.Equal(elestronicCard.CurrentSum, money);
        }

        #endregion

    }
}
