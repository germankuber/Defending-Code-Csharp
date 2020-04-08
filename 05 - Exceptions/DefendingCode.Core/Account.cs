using System;
using System.Collections.Generic;
using System.Linq;
using DefendingCode.Utilities;
using Optional;

namespace DefendingCode.Core
{
    public class Account
    {
        public decimal Money { get; set; }
        public string Type { get; set; } = String.Empty;
        public string AccountNumber { get; set; } = String.Empty;
        private List<AccountToTransfer> _transfers = new List<AccountToTransfer>();

        public Account(decimal money = 100)
        {
            Guard.ThrowIfNull(money, "Debe ingresar una fecha", nameof(money));
            Money = money;
        }


        public void ExtractMoney(string moneyToExtract, DateTime dateOfExtract)
        {
            Guard.ThrowIfNullOrEmpty(moneyToExtract, "Debe ingresar un monto", nameof(moneyToExtract));
            decimal moneyToExtractDecimal = Guard.ThrowIfNotPositiveDecimal(moneyToExtract, "Formato incorrecto", nameof(moneyToExtract));

            if (moneyToExtractDecimal > Money)
                return;

            if (!ValidateDate(dateOfExtract).Success)
                return;

            Money = Money - moneyToExtractDecimal;
        }


        public void TransferMoney(AccountToTransfer accountToTransfer)
        {
            if (accountToTransfer?.AccountToTransferMoney is null) throw new ArgumentNullException(nameof(accountToTransfer));
            Guard.ThrowIfNotPositiveDecimal(accountToTransfer.MoneyToTransfer, "Debe ingresar un monto válido", nameof(accountToTransfer.MoneyToTransfer));

            Money = Money - accountToTransfer.MoneyToTransfer;
        }

        //TODO: 01 - Refactor

        public AccountToTransfer? SearchTransfer(int transferId)
        {
            if (_transfers.All(x => x.TransferId != transferId))
                return null;

            return _transfers.First(x => x.TransferId == transferId);
        }
        //TODO: 02 - Exception
        public AccountToTransfer SearchTransferWithException(int transferId)
        {
            if (_transfers.All(x => x.TransferId != transferId))
                throw new AccountToTransferDoesNotExistException("La cuenta a la que intenta transferir no existe");

            return _transfers.First(x => x.TransferId == transferId);
        }

        //TODO: 03 - More exceptions
        public AccountToTransfer SearchTransfer(int transferId, DateTime date, AccountToTransfer account)
        {
            Guard.ThrowIfNull(date, "Debe ingresar una fecha", nameof(date));
            Guard.ThrowIfNull(account, "Debe ingresar una Cuenta", nameof(date));

            if (_transfers.All(x => x.TransferId != transferId))
                throw new AccountToTransferDoesNotExistException("La cuenta a la que intenta transferir no existe");

            return _transfers.First(x => x.TransferId == transferId);
        }



        public void TransferMoney(Option<AccountToTransfer> accountToTransfer)
        {
            accountToTransfer.Match(
                some: x =>
                {
                    return Money = Money - x.MoneyToTransfer;
                },
                none: () =>
                {
                    throw new ArgumentNullException("Debe ingresar un monto válido");
                });
        }
        public OperationResult ValidateDate(DateTime? dateOfExtract)
        {
            if (!dateOfExtract.HasValue)
                return OperationResult.Error("Debe ingresar un valor para la fecha");

            if ((dateOfExtract.Value.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.Value.DayOfWeek == DayOfWeek.Sunday))
                return OperationResult.Error("No se pueden realizar operaciones los fines de semana");

            return OperationResult.Successful();
        }
    }
}

public class AccountToTransferDoesNotExistException : Exception
{

    public AccountToTransferDoesNotExistException() { }
    public AccountToTransferDoesNotExistException(string message) : base(message) { }
    public AccountToTransferDoesNotExistException(string message, Exception inner) : base(message, inner) { }
}
}
