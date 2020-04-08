using DefendingCode.Utilities;
using RailSharp;

namespace DefendingCode.Core
{
    public class ExtractMoney
    {
        public Money Money { get; }

        public ExtractMoney(decimal moneyValue)
        {
            Guard.ThrowIfNotPositiveDecimal(moneyValue, "Formato incorrecto", nameof(moneyValue));
            Money = new Money(moneyValue);
        }

        public Result<IExtractMoneyError> IsValidToExtract(decimal currentMoneyAccount)
        {
            if (Money.Value > currentMoneyAccount)
                return Result.Failure<IExtractMoneyError>(new DoesNotHaveEnoughMoneyError());
            return Result.Success();
        }

        public Result<IExtractMoneyError, decimal> Extract(decimal currentMoneyAccount) =>
            IsValidToExtract(currentMoneyAccount)
                .Map(() => currentMoneyAccount - Money.Value);

        public interface IExtractMoneyError
        {

        }
        public class DoesNotHaveEnoughMoneyError : IExtractMoneyError { }
        public class OtherError : IExtractMoneyError { }
    }
}