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

            if (!ValidateDate(dateOfExtract))
                return;

            Money = Money - moneyToExtractDecimal;
        }


        public void TransferMoney(AccountToTransfer accountToTransfer)
        {
            if (accountToTransfer?.AccountToTransferMoney is null) throw new ArgumentNullException(nameof(accountToTransfer));
            Guard.ThrowIfNotPositiveDecimal(accountToTransfer.MoneyToTransfer, "Debe ingresar un monto válido", nameof(accountToTransfer.MoneyToTransfer));

            Money = Money - accountToTransfer.MoneyToTransfer;
        }


        public AccountToTransfer? SearchTransfer(int transferId)
        {
            if (_transfers.All(x => x.TransferId != transferId))
                return null;

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

        //TODO: 01 - Refactorizar
        public bool ValidateDate(DateTime? dateOfExtract)
        {
            if (!dateOfExtract.HasValue) return false;
            if ((dateOfExtract.Value.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.Value.DayOfWeek == DayOfWeek.Sunday))
                return false;

            return true;
        }

        //TODO: 02 - Validaciones con ref
        public bool ValidateDateWithRef(DateTime? dateOfExtract, ref string errorMessage)
        {
            if (!dateOfExtract.HasValue)
            {
                errorMessage = "Debe ingresar un valor para la fecha";
                return false;
            }
            if ((dateOfExtract.Value.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.Value.DayOfWeek == DayOfWeek.Sunday))
            {
                errorMessage = "No se pueden realizar operaciones los fines de semana";
                return false;
            }
            return true;
        }

        //TODO: 02 - Validaciones con out
        public bool ValidateDateWithOut(DateTime? dateOfExtract, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (!dateOfExtract.HasValue)
            {
                errorMessage = "Debe ingresar un valor para la fecha";
                return false;
            }
            if ((dateOfExtract.Value.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.Value.DayOfWeek == DayOfWeek.Sunday))
            {
                errorMessage = "No se pueden realizar operaciones los fines de semana";
                return false;
            }
            return true;
        }


        //TODO: 03 - Validaciones con tuplas
        public (bool IsValid, string ErrorMessage) ValidateDateWithTuple(DateTime? dateOfExtract)
        {
            if (!dateOfExtract.HasValue)
                return (IsValid: false, ErrorMessage: "Debe ingresar un valor para la fecha");

            if ((dateOfExtract.Value.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.Value.DayOfWeek == DayOfWeek.Sunday))
                return (false, "No se pueden realizar operaciones los fines de semana");

            return (true, string.Empty);
        }


        //TODO: 04- Validaciones con tuplas
        public OperationResult ValidateDateWithObject(DateTime? dateOfExtract)
        {
            if (!dateOfExtract.HasValue)
                return OperationResult.Error("Debe ingresar un valor para la fecha");

            if ((dateOfExtract.Value.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.Value.DayOfWeek == DayOfWeek.Sunday))
                return OperationResult.Error("No se pueden realizar operaciones los fines de semana");

            return OperationResult.Successful();
        }
    }
}
