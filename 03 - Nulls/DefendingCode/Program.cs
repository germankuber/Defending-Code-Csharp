using System;
using DefendingCode.Core;

namespace DefendingCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();

            account.ExtractMoney(null, DateTime.Now);


            //TODO: 05 - Call with null
            account.TransferMoney(null);
            Console.ReadKey();
        }
    }
}
