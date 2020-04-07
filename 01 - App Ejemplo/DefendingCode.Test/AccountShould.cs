using System;
using DefendingCode.Core;
using FluentAssertions;
using Xunit;

namespace DefendingCode.Test
{
    public class AccountShould
    {
        private readonly Account _sut;

        public AccountShould()
        {
            _sut = new Account();
        }
        [Fact]
        public void Throw_Error_MoneyToExtract_Wrong_Format()
        {
            string extractMoney = "22m";

            FluentActions.Invoking(() => _sut.ExtractMoney(extractMoney, DateTime.Now)).Should()
                .Throw<ArgumentException>()
                .WithMessage("Formato incorrecto");


        }

        [Fact]
        public void Throw_Error_MoneyToExtract_Less_Than_Zero()
        {
            string extractMoney = "-1";

            FluentActions.Invoking(() => _sut.ExtractMoney(extractMoney, DateTime.Now)).Should()
                .Throw<ArgumentException>()
                .WithMessage("Debe ingresar un monto mayor a cero");

        }

        [Fact]
        public void Throw_Error_MoneyToExtract_Is_Weekend()
        {
            string extractMoney = "-1";

            FluentActions.Invoking(() => _sut.ExtractMoney(extractMoney,new DateTime(2020,4,25))).Should()
                .Throw<ArgumentException>()
                .WithMessage("No se entrega dinero los fines de semana");

        }

        [Fact]
        public void Throw_Error_MoneyToExtract_More_Money_Than_Have()
        {
            _sut.ExtractMoney("100", DateTime.Now);

            FluentActions.Invoking(() => _sut.ExtractMoney("10", DateTime.Now)).Should()
                .Throw<ArgumentException>()
                .WithMessage("No tiene fondos suficientes");

        }

    }
}
