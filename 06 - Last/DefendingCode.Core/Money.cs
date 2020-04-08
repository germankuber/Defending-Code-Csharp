using DefendingCode.Utilities;

namespace DefendingCode.Core
{
    public class Money
    {
        public decimal Value { get; }

        public Money(decimal value)
        {
            Guard.ThrowIfNotPositiveDecimal(value, "Formato incorrecto", nameof(value));
            Value = value;
        }
    }
}