using System;

using BLL.DataFunctionalSubsystem.Interface;
using BLL.ServiceInterface;

namespace BLL.DataFunctionalSubsystem.Class
{
    public class PrivateUniversalCard : IUniversalBankCard, IValidable
    {
        private decimal amountMoney;

        internal PrivateUniversalCard() { amountMoney = 0; BankName = "Private Bank"; }
        internal PrivateUniversalCard(decimal sum) : base() { amountMoney = sum; }


        public IIDCode OwnerCode { get; internal set; }


        public string BankName { get; private set; }
        public string BankCardNumber { get; internal set; }
        public DateTime HowLongValid { get; internal set; }


        public bool PutMoney(decimal sum) { amountMoney += sum; return true; }
        public bool WithdrawMoney(decimal sum)
        {
            if (amountMoney < sum) { return false; }

            amountMoney -= sum;
            return false;
        }


        public bool isValid()
        {
            if (OwnerCode != null)
            {
                return true;
            }

            return false;
        }
    }
}
