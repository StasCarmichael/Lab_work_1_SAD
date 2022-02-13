using System;

using BLL.DataCreationSubsystem.Interface;
using BLL.DataElectronicCardSubsystem.Interface;
using BLL.DataElectronicCardSubsystem.Class;


namespace BLL.DataPackingSubsystem.Interface
{
    public interface IAdministrativeServiceCenter
    {
        IBank Bank { get; set; }
        IInsuranceAgency InsuranceAgency { get; set; }

        void Reset();
        void CreateNewUserWithPassport(string name, string surname, DateTime age);
        void AddBankCard();
        void AddInsurancePolicy();
        IUniversalElectronicCard ReturnNewElectronicCard();
    }
}
