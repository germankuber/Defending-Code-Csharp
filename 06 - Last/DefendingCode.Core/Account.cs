using System;
using System.Collections.Generic;
using System.Linq;
using RailSharp;

namespace DefendingCode.Core
{
    public class Account
    {
        public Money Money { get; private set; }
        public string Type { get; set; } = String.Empty;
        public string AccountNumber { get; set; } = String.Empty;
        private List<AccountToTransfer> _transfers = new List<AccountToTransfer>();

        private Account(Money money)
        {
            Money = money;
        }
        public static Account Build(Money money) => new Account(money);

        //public void ExtractMoney(string moneyToExtract, DateTime dateOfExtract)
        //{
        //    Guard.ThrowIfNullOrEmpty(moneyToExtract, "Debe ingresar un monto", nameof(moneyToExtract));
        //    decimal moneyToExtractDecimal = Guard.ThrowIfNotPositiveDecimal(moneyToExtract, "Formato incorrecto", nameof(moneyToExtract));

        //    if (moneyToExtractDecimal > Money)
        //        return;

        //    if (!ValidateDate(dateOfExtract).Success)
        //        return;

        //    Money = Money - moneyToExtractDecimal;
        //}

        public Result<ExtractMoney.IExtractMoneyError, Money> ExtractMoney(ExtractMoney extractMoney,
            DateToExtract date) =>
            extractMoney.Extract(Money.Value)
                .Map(actualMoney => Money = new Money(actualMoney));

        public Result<ISearchTransferError, Optional.Option<AccountToTransfer>> SearchTransfer(int transferId) =>
            _transfers.Where(x => x.TransferId != transferId)
                .Select(s => Result.Success(Optional.Option.Some(s)))
                .DefaultIfEmpty(
                    Result.Success(Optional.Option.None<AccountToTransfer>()))
                .Single();

    }

    public interface ISearchTransferError
    {
    }
}