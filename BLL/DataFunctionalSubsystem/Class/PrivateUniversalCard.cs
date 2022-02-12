﻿using System;
using BLL.DataFunctionalSubsystem.Interface;
using BLL.ServiceInterface;

namespace BLL.DataFunctionalSubsystem.Class
{
    public class PrivateUniversalCard : IUniversalBankCard, IValidable
    {
        internal PrivateUniversalCard() { CurrentSum = 0; BankName = "Private Bank"; }
        internal PrivateUniversalCard(decimal sum) : base() { CurrentSum = sum; }


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
