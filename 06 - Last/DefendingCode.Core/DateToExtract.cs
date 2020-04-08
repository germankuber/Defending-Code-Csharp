using System;
using DefendingCode.Utilities;
using RailSharp;

namespace DefendingCode.Core
{
    public class DateToExtract
    {
        public DateTime Date { get; set; }

        public DateToExtract(DateTime date)
        {
            Guard.ThrowIfNull(date, "Debe ingresar un valor para la fecha", nameof(date));
        }

        public static Result<IValidateDateToExtractMoneyError, DateToExtract> Build(DateTime date)
        {
            if (date == DateTime.MinValue)
                return Result.Failure<IValidateDateToExtractMoneyError>(new DateRequiredError());
            if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
                return Result.Failure<IValidateDateToExtractMoneyError>(new DateToBeWeekDayError());
            return Result.Success(new DateToExtract(date));

        }

        public class DateToBeWeekDayError : IValidateDateToExtractMoneyError
        {
        }

        public interface IValidateDateToExtractMoneyError
        {
        }
        public class DateRequiredError : IValidateDateToExtractMoneyError
        {
        }

    }
}