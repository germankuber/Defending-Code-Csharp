using System;

namespace DefendingCode.Core
{
    public class OperationResult
    {
        public bool Success { get; }
        public string ErrorMessage { get; }

        private OperationResult(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }

        public static OperationResult Successful() =>
            new OperationResult(true, String.Empty);

        public static OperationResult Error(string errorMessage) =>
            new OperationResult(false, errorMessage);

    }
}