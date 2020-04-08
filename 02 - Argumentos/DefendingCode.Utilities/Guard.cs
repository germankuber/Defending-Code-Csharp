using System;

namespace DefendingCode.Utilities
{
    public static class Guard
    {
        //TODO: 07 - Guard 
        public static void ThrowIfNullOrEmpty(string argumentValue, string message, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(argumentValue)) throw new ArgumentException(message, parameterName);
        }
        public static void ThrowIfNull<TArgument>(TArgument argumentValue, string message, string parameterName)
        {
            if (argumentValue == null) throw new ArgumentException(message, parameterName);
        }
        public static void ThrowIfNull(DateTime argumentValue, string message, string parameterName)
        {
            if (argumentValue == null || argumentValue == DateTime.MinValue) throw new ArgumentException(message, parameterName);
        }

        public static decimal ThrowIfNotPositiveDecimal(string argumentValue, string message, string parameterName)
        {
            var success = decimal.TryParse(argumentValue, out decimal result);
            if (!success || result < 0) throw new ArgumentException(message, parameterName);

            return result;
        }
    }
}
