using Xunit.Abstractions;
using VideogamesStore.Domain.Value_Objects;
using VideogamesStore.Domain.Exceptions;
using VideogamesStore.Tests.Messages;


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

            Price price = new Price(code, amount);

            Assert.Equal(code, price.Code);
            Assert.Equal(amount, price.Amount);
        }
        [Theory]
        [InlineData("COP", 100)]
        [InlineData("ARP", 2431)]
        [InlineData("SOL", 532)]
        [InlineData("BLV", 875322)]
        public void Create_Should_RaiseNotAllowedCurrencyException(string code, decimal amount)
        {

            var exception = Assert.Throws<NotAllowedCurrencyException>(() => new Price(code, amount));

            Assert.Equal(ExpectedTestMessages.InvalidCurrency, exception.Message);
            GetOutput(exception.Message);
        }

        [Theory]
        [InlineData("DOP", -150)]
        [InlineData("USD", -0.01)]
        [InlineData("GBP", -187)]
        [InlineData("USD", -1058)]
        public void Create_Should_RaiseInvalidPriceException(string code, decimal price)
        {
            var exception = Assert.Throws<InvalidPriceException>(() => new Price(code, price));
            Assert.Equal($"{ExpectedTestMessages.InvalidAmount + price}", exception.Message);
            output.WriteLine(exception.Message);
        }

        [Theory]
        [InlineData("GBP", 4500)]
        [InlineData("DOP", 452213)]
        [InlineData("USD", 3214)]
        [InlineData("EUR", 542)]
        public void AtomicValues_ShouldBeEqualTo_ReceivedValues(string code, decimal amount)
        {
            Price price = new Price(code, amount);

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

        private void GetOutput(string message, string origin = "exception")
        {
            output.WriteLine($"Message from the {origin}: {message}");
        }
    }
}
