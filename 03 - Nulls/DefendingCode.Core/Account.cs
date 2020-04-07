using System;
using System.Collections.Generic;
using DefendingCode.Utilities;

namespace DefendingCode.Core
{
    public class Account
    {
        public decimal Money { get; set; }
        public string Type { get; set; }
        public string AccountNumber { get; set; }
        private List<AccountToTransfer> _transfers = new List<AccountToTransfer>();

        public Account(decimal money = 100)
        {
            Guard.ThrowIfNull(money, "Debe ingresar una fecha", nameof(money));
            Money = money;
        }
        //public void ExtractMoney(string moneyToExtract, DateTime dateOfExtract)
        //{
        //    Guard.ThrowIfNullOrEmpty(moneyToExtract, "Debe ingresar un monto", nameof(moneyToExtract));
        //    Guard.ThrowIfNull(dateOfExtract, "Debe ingresar una fecha", nameof(dateOfExtract));
        //    decimal moneyToExtractDecimal = Guard.ThrowIfNotPositiveDecimal(moneyToExtract, "Formato incorrecto", nameof(moneyToExtract));

        //    if (moneyToExtractDecimal > Money)
        //        return;

        //    if ((dateOfExtract.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.DayOfWeek == DayOfWeek.Sunday))
        //        return;

        //    Money = Money - moneyToExtractDecimal;
        //}

        public void ExtractMoney(string moneyToExtract, DateTime dateOfExtract)
        {
            Guard.ThrowIfNullOrEmpty(moneyToExtract, "Debe ingresar un monto", nameof(moneyToExtract));
            decimal moneyToExtractDecimal = Guard.ThrowIfNotPositiveDecimal(moneyToExtract, "Formato incorrecto", nameof(moneyToExtract));

            if (moneyToExtractDecimal > Money)
                return;

            if (!ValidateDate(dateOfExtract))
                return;

            Money = Money - moneyToExtractDecimal;
        }


        public bool ValidateDate(DateTime? dateOfExtract)
        {
            //TODO: 01 - Implemento Guard
            if (!dateOfExtract.HasValue) return false;
            if ((dateOfExtract.Value.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.Value.DayOfWeek == DayOfWeek.Sunday))
                return false;

            return true;
        }


        public void TransferMoney(AccountToTransfer accountToTransfer)
        {
            //TODO: 02 - Implemento transferencia.

            if (accountToTransfer is null) throw new ArgumentNullException(nameof(accountToTransfer));
            if (accountToTransfer.AccountToTransferMoney is null) throw new ArgumentNullException(nameof(accountToTransfer));
            Guard.ThrowIfNotPositiveDecimal(accountToTransfer.MoneyToTransfer, "Debe ingresar un monto válido", nameof(accountToTransfer.MoneyToTransfer));

            Money = Money - accountToTransfer.MoneyToTransfer;
        }

        //public void TransferMoney(AccountToTransfer accountToTransfer)
        //{
        //    //TODO: 03 - Elvis Operator
        //    if (accountToTransfer?.AccountToTransferMoney is null) throw new ArgumentNullException(nameof(accountToTransfer));
        //    Guard.ThrowIfNotPositiveDecimal(accountToTransfer.MoneyToTransfer, "Debe ingresar un monto válido", nameof(accountToTransfer.MoneyToTransfer));

        //    Money = Money - accountToTransfer.MoneyToTransfer;
        //}


        //public AccountToTransfer SearchTransfer(int transferId)
        //{
        //    if (_transfers.All(x => x.TransferId != transferId))
        //        return null;

        //    return _transfers.First(x => x.TransferId == transferId);
        //}


        //TODO: 04 
        //Install-Package Fody
        //Install-Package NullGuard.Fody

        //TODO: 06
        //Install-Package Optional 
        //public void TransferMoney(Option<AccountToTransfer> accountToTransfer)
        //{
        //    accountToTransfer.Match(
        //        some: x =>
        //        {
        //            return Money = Money - x.MoneyToTransfer;
        //        },
        //        none: () =>
        //        {
        //            throw new ArgumentNullException("Debe ingresar un monto válido");
        //        });
        //}

    }
}
