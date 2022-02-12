using System;
using BLL.DataFunctionalSubsystem.Interface;
using BLL.ServiceInterface;

namespace BLL.DataFunctionalSubsystem.Class
{
    public class MonoUniversalCard : IUniversalBankCard, IValidable
    {
        internal MonoUniversalCard() { CurrentSum = 0; BankName = "Mono Bank"; }
        internal MonoUniversalCard(decimal sum) : base() { CurrentSum = sum; }


        public IIDCode OwnerCode { get; internal set; }


        public string BankName { get; private set; }
        public string BankCardNumber { get; internal set; }
        public DateTime HowLongValid { get; internal set; }


        public decimal CurrentSum { get; private set; }
        public bool PutMoney(decimal sum) { CurrentSum += sum; return true; }
        public bool WithdrawMoney(decimal sum)
        {
            if (CurrentSum < sum) { return false; }

            CurrentSum -= sum;
            return false;
        }


        public bool IsValid()
        {
            if (OwnerCode != null)
                if (HowLongValid.Year <= DateTime.Now.Year && HowLongValid.Month <= DateTime.Now.Month)
                    return true;

            return false;
        }
            }
}
