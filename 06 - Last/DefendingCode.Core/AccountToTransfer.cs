using System;

namespace DefendingCode.Core
{
    public class AccountToTransfer
    {
        public int TransferId { get; set; }
        public Account AccountToTransferMoney { get; }
        public DateTime DateToTransfer { get; }
        public decimal MoneyToTransfer { get; }
        public AccountToTransfer(Account accountToTransfer, DateTime dateToTransfer, decimal moneyToTransfer)
        {
            AccountToTransferMoney = accountToTransfer;
            DateToTransfer = dateToTransfer;
            MoneyToTransfer = moneyToTransfer;
        }

    }
}