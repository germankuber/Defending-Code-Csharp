using System;

namespace DefendingCode.Core
{
    public class AccountToTransferDoesNotExistException : Exception
    {

        public AccountToTransferDoesNotExistException() { }
        public AccountToTransferDoesNotExistException(string message) : base(message) { }
        public AccountToTransferDoesNotExistException(string message, Exception inner) : base(message, inner) { }
    }
}