using System;

using BLL.DataCreationSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Class;

namespace BLL.DataCreationSubsystem.Class
{
    public class MonoBank : IBank
    {
        //Card_Format = 1234-1234-1234-1234

        const int VALID_TIME = 4;
        const int FIRST_DAY = 1;

        const int NUMBER_OF_GROUP = 4;
        const int NUMBER_OF_DIGISTS = 4;

        const char FIRST_NUM = '4';
        const char SECOND_NUM = '2';

        const int MIN_NUMBER = 0;
        const int MAX_NUMBER = 9;


        private string CreatePrivateUniversalCardNumber()
        {
            Random random = new Random();
            string cardNumber = string.Empty;

            for (int gro = 0; gro < NUMBER_OF_GROUP; gro++)
            {
                for (int dig = 0; dig < NUMBER_OF_DIGISTS; dig++)
                {
                    if (gro == 0 && dig == 0) { cardNumber += FIRST_NUM; }
                    else if (gro == 0 && dig == 1) { cardNumber += SECOND_NUM; }
                    else
                    {
                        cardNumber += random.Next(MIN_NUMBER, MAX_NUMBER);
                    }
                }
            }

            return cardNumber;
        }


        public IUniversalBankCard CreateUniversalBankCard(IIDCode owner)
        {
            MonoUniversalCard card = new MonoUniversalCard();

            card.OwnerCode = owner;
            card.BankCardNumber = CreatePrivateUniversalCardNumber();
            card.HowLongValid = new DateTime(DateTime.Now.Year + VALID_TIME, DateTime.Now.Month, FIRST_DAY);

            return card;
        }
        public IUniversalBankCard CreateUniversalBankCard(IIDCode owner, decimal sum)
        {
            IUniversalBankCard bankCard = CreateUniversalBankCard(owner);
            bankCard.PutMoney(sum);

            return bankCard;
        }

    }
}
