using System;
using DefendingCode.Utilities;

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
        //public void ExtractMoney(string moneyToExtract, DateTime dateOfExtract)
        //{
        //    decimal moneyToExtractDecimal = decimal.Parse(moneyToExtract);

        //    if (moneyToExtractDecimal > Money)
        //        return;
        //    if ((dateOfExtract.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.DayOfWeek == DayOfWeek.Sunday))
        //        return;

        //    Money = Money - moneyToExtractDecimal;
        //}



        //public void ExtractMoney(string moneyToExtract, DateTime dateOfExtract)
        //{
        //    //TODO: 02 - Validamos parametros de entrada
        //    var success = decimal.TryParse(moneyToExtract, out decimal moneyToExtractDecimal);
        //    if (success)
        //    {
        //        if (moneyToExtractDecimal > Money)
        //            return;
        //        if ((dateOfExtract.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.DayOfWeek == DayOfWeek.Sunday))
        //            return;

        //        Money = Money - moneyToExtractDecimal;
        //    }
        //}

        //public void ExtractMoney(string moneyToExtract, DateTime dateOfExtract)
        //{
        //    //TODO: 03 - Guard Clauses
        //    var success = decimal.TryParse(moneyToExtract, out decimal moneyToExtractDecimal);
        //    if (!success) throw new ArgumentException("Formato incorrecto");


        //    if (moneyToExtractDecimal > Money)
        //        return;
        //    if ((dateOfExtract.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.DayOfWeek == DayOfWeek.Sunday))
        //        return;

        //    Money = Money - moneyToExtractDecimal;
        //}


        //public void ExtractMoney(string moneyToExtract, DateTime dateOfExtract)
        //{
        //    decimal moneyToExtractDecimal;
        //    //TODO: 04 - Detalles en errores
        //    var success = decimal.TryParse(moneyToExtract, out moneyToExtractDecimal);
        //    if (!success) throw new ArgumentException("Formato incorrecto", nameof(moneyToExtract));


        //    if (moneyToExtractDecimal == 0) throw new ArgumentException("El monto a retirar debe de ser mayor a 0", nameof(moneyToExtract));


        //    if (moneyToExtractDecimal > Money)
        //        return;
        //    if ((dateOfExtract.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.DayOfWeek == DayOfWeek.Sunday))
        //        return;

        //    Money = Money - moneyToExtractDecimal;
        //}


        //public void ExtractMoney(string moneyToExtract, DateTime dateOfExtract)
        //{
        //    //TODO: 05 - Mas guards
        //    if (string.IsNullOrWhiteSpace(moneyToExtract))
        //        throw new ArgumentException("Debe ingresar un monto", nameof(moneyToExtract));

        //    if (dateOfExtract != null && dateOfExtract != DateTime.MinValue)
        //        throw new ArgumentException("Debe ingresar una fecha", nameof(dateOfExtract));

        //    decimal moneyToExtractDecimal;
        //    var success = decimal.TryParse(moneyToExtract, out moneyToExtractDecimal);
        //    if (!success) throw new ArgumentException("Formato incorrecto", nameof(moneyToExtract));

        //    if (moneyToExtractDecimal == 0) throw new ArgumentException("El monto a retirar debe de ser mayor a 0", nameof(moneyToExtract));


        //    if (moneyToExtractDecimal > Money)
        //        return;


        //    if ((dateOfExtract.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.DayOfWeek == DayOfWeek.Sunday))
        //        return;

        //    Money = Money - moneyToExtractDecimal;
        //}


        public void ExtractMoney(string moneyToExtract, DateTime dateOfExtract)
        {
            //TODO: 07 - Utilizar Guards
            Guard
            if (string.IsNullOrWhiteSpace(moneyToExtract))
                throw new ArgumentException("Debe ingresar un monto", nameof(moneyToExtract));

            if (dateOfExtract != null && dateOfExtract != DateTime.MinValue)
                throw new ArgumentException("Debe ingresar una fecha", nameof(dateOfExtract));

            decimal moneyToExtractDecimal;
            var success = decimal.TryParse(moneyToExtract, out moneyToExtractDecimal);
            if (!success) throw new ArgumentException("Formato incorrecto", nameof(moneyToExtract));

            if (moneyToExtractDecimal == 0) throw new ArgumentException("El monto a retirar debe de ser mayor a 0", nameof(moneyToExtract));


            if (moneyToExtractDecimal > Money)
                return;


            if ((dateOfExtract.DayOfWeek == DayOfWeek.Saturday) || (dateOfExtract.DayOfWeek == DayOfWeek.Sunday))
                return;

            Money = Money - moneyToExtractDecimal;
        }
    }
}
