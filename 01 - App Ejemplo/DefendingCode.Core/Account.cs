using System;

namespace DefendingCode.Core
{
    public class Account
    {
        public decimal Money { get; set; }
        public string AccountNumber { get; set; }

        public Account(decimal money = 100)
        {
            Money = money;
        }
        public void ExtractMoney(string moneyToExtract, DateTime dateOfExtract)
        {
            decimal moneyToExtractDecimal = decimal.Parse(moneyToExtract);

            if (moneyToExtractDecimal > Money)
                return;
            if ((dateOfExtract.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.DayOfWeek == DayOfWeek.Sunday))
                return;

            Money = Money - moneyToExtractDecimal;
        }
    }
}
