using Xunit.Abstractions;
using VideogamesStore.Domain.Value_Objects;
using VideogamesStore.Tests.Messages;
using VideogamesStore.Domain.Exceptions.ValueObjects.Price;
using VideogamesStore.Domain.Shared.Errors;
using VideogamesStore.Domain.Shared.Enums;
using VideogamesStore.Domain.Shared.Utils;

namespace VideogamesStore.Tests.Domain.Value_Objects
{

    public class PriceTest
    {
        private ITestOutputHelper output;
        public PriceTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Theory]
        [InlineData("USD", 100)]
        [InlineData("DOP", 14623)]
        [InlineData("GBP", 75)]
        [InlineData("USD", 2354)]
        public void Create_Should_BeSuccessful(string code, decimal amount)
        {

            Price price = Price.Create(code, amount);
            ValidationResponse errors = Price.Validate(code, amount);

            Assert.Equal(code, price.Code);
            Assert.Equal(amount, price.Amount);
            Assert.True(errors.Errors.Count() is 0);
        }

        [Theory]
        [InlineData("COP", 100)]
        [InlineData("ARP", 2431)]
        [InlineData("SOL", 532)]
        [InlineData("BLV", 875322)]
        [InlineData("DOP", -150)]
        [InlineData("USD", -0.01)]
        [InlineData("GBP", -187)]
        [InlineData("USD", -1058)]
        [InlineData("ARP", -2431)]
        [InlineData("SOL", -532)]
        [InlineData("BLV", -875322)]
        public void CreateInvalidPrice_Should_Fail(string code, decimal amount)
        {

            var price = Price.Create(code, amount);
            var errors = Price.Validate(code, amount);

            //Validating in case the currency is valid but the price isnt
            if (amount < 0 && Enum.IsDefined(typeof(AllowedCurrencies), code))
            {
                Assert.True(errors.Errors.Count() is 1);
                Assert.Equal(errors.Errors[0].Cause, ErrorCause.NegativePrice);
            }

            //Validating in case the price is valid but the currency isnt
            if(amount > 0 && !Enum.IsDefined(typeof(AllowedCurrencies), code))
            {
                Assert.True(errors.Errors.Count() is 1);
                Assert.Equal(errors.Errors[0].Cause, ErrorCause.NotAllowedCurrency);
            }

            if(amount < 0 && !Enum.IsDefined(typeof(AllowedCurrencies), code))
            {
                Assert.True(errors.Errors.Count() is 2);
                Assert.Equal(errors.Errors[0].Cause, ErrorCause.NegativePrice);
                Assert.Equal(errors.Errors[1].Cause, ErrorCause.NotAllowedCurrency);
            }

            Assert.True(price is null);
        }


        [Theory]
        [InlineData("GBP", 4500)]
        [InlineData("DOP", 452213)]
        [InlineData("USD", 3214)]
        [InlineData("EUR", 542)]
        public void AtomicValues_ShouldBeEqualTo_ReceivedValues(string code, decimal amount)
        {
            Price price = Price.Create(code, amount);

            string codeTest = default;
            decimal amountTest = default;

            foreach(object value in price.GetAtomicValues())
            {
                if (value is string codeValue) codeTest = codeValue;

                if(value is decimal amountValue) amountTest = amountValue;
            }

            Assert.Equal(codeTest, code);
            Assert.Equal(amountTest, amount);
        }
    }
}
