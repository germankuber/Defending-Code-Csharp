using System;
using DefendingCode.Core;

namespace DefendingCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();

            //TODO: 01 - Experiencia de usuario
            account.ExtractMoney(null, DateTime.Now);

            Console.ReadKey();
        }
    }
}
