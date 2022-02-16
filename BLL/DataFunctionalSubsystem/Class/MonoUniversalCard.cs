using System;
using BLL.DataFunctionalSubsystem.Interface;

namespace BLL.DataFunctionalSubsystem.Class
{
    [Serializable]
    public class MonoUniversalCard : IUniversalBankCard
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
            return true;
        }


        public bool IsValid()
        {
            if (OwnerCode != null)
            {
                if (HowLongValid.Year > DateTime.Now.Year)
                {
                    return true;
                }
                else if (HowLongValid.Year == DateTime.Now.Year)
                {
                    if (HowLongValid.Month >= DateTime.Now.Month) { return true; }

                    return false;
                }
                else { return false; }
            }

            return false;
        }
    }
}
