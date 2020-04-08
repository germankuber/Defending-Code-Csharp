using System;
using DefendingCode.Core;
using FluentAssertions;
using Optional;
using Optional.Unsafe;
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
            // Arrange
            string extractMoney = "22m";

            //Act
            Action act = () => _sut.ExtractMoney(extractMoney, DateTime.Now);

            //Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Formato incorrecto (Parameter 'moneyToExtract')");

        }

        [Fact]
        public void Throw_Error_MoneyToExtract_Is_Null()
        {
            FluentActions.Invoking(() => _sut.ExtractMoney(null, DateTime.Now)).Should()
                .Throw<ArgumentException>()
                .WithMessage("Debe ingresar un monto (Parameter 'moneyToExtract')");
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

            FluentActions.Invoking(() => _sut.ExtractMoney(extractMoney, new DateTime(2020, 4, 25))).Should()
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

        [Fact]
        public void Throw_Error_AccountToTransfer_Is_Null()
        {
            FluentActions.Invoking(() => _sut.TransferMoney(Option.None<AccountToTransfer>())).Should()
                .Throw<ArgumentException>();
        }

        [Fact]
        public void Transfer_Money()
        {
            FluentActions.Invoking(() => _sut.TransferMoney(Option.Some(new AccountToTransfer(new Account(), DateTime.Now, 100))))
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Debe ingresar un monto válido");

        }

        [Fact]
        public void Safety_Use()
        {
            var optionWithoutValue = Option.None<int>();

            var valueOrFail = optionWithoutValue.ValueOrFailure();
            var valueOrDefault = optionWithoutValue.ValueOrDefault();

            var alternative = optionWithoutValue.ValueOr(10);
            var elseValue = optionWithoutValue.Else(Option.Some(20));
        }


        [Fact]
        public void Set_Error_Message_Date_Is_Null()
        {
            var errorMessage = string.Empty;

            _sut.ValidateDateWithRef(null, ref errorMessage).Should().BeFalse();

            errorMessage.Should().Be("Debe ingresar un valor para la fecha");
        }


        [Fact]
        public void Set_Error_Message_Date_Is_Null_With_Out()
        {
            _sut.ValidateDateWithOut(null, out string errorMessage).Should().BeFalse();

            errorMessage.Should().Be("Debe ingresar un valor para la fecha");
        }

        [Fact]
        public void Set_Error_Message_Date_Is_Null_With_Tuple()
        {
            var result = _sut.ValidateDateWithTuple(null);

            result.ErrorMessage.Should().Be("Debe ingresar un valor para la fecha");
            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Set_Error_Message_Date_Is_Null_With_Object()
        {
            var result = _sut.ValidateDateWithObject(null);

            result.ErrorMessage.Should().Be("Debe ingresar un valor para la fecha");
            result.Success.Should().BeFalse();
        }


    }
}
