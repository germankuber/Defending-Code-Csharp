using System;
using DefendingCode.Core;
using RailSharp;
using Xunit;

namespace DefendingCode.Test
{
    public class AccountShould
    {
        private readonly Account _sut;

        public AccountShould()
        {
            _sut = Account.Build(new Money(150));
        }

        [Fact]
        public void Extract_Money()
        {
            _sut.ExtractMoney(new ExtractMoney(50), new DateToExtract(DateTime.Now))
                .Map(GetValueMap)
                .Catch<ExtractMoney.DoesNotHaveEnoughMoneyError>(DoesNotHaveEnoughMoneyErrorHandler)
                .Catch<ExtractMoney.OtherError>(OtherErrorHandler);

        }


        [Fact]
        public void Search_Transfer()
        {
            _sut.SearchTransfer(2)
                .Map(x =>
                        {
                            x.Match(s =>
                            {
                                //Encuentro la cuenta
                            }, () =>
                            {
                                //no encontro el valor
                            });
                            return x;
                        });

        }

        private decimal GetValueMap(Money value)
        {
            throw new NotImplementedException();
        }

        private decimal DoesNotHaveEnoughMoneyErrorHandler(ExtractMoney.DoesNotHaveEnoughMoneyError doesNotHaveEnoughMoneyError)
        {
            throw new NotImplementedException();
        }
        private decimal OtherErrorHandler(ExtractMoney.OtherError doesNotHaveEnoughMoneyError)
        {
            throw new NotImplementedException();
        }
    }
}
