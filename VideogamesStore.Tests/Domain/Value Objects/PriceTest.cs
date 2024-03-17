
using Xunit.Abstractions;
using VideogamesStore.Domain.Value_Objects;
using VideogamesStore.Domain.Exceptions;
using VideogamesStore.Domain.Shared.Constants;

namespace VideogamesStore.Tests.Domain.Value_Objects
{
    
    public class PriceTest
    {
        private ITestOutputHelper output;
        public PriceTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void Successful_Price_Creation()
        {
            //string code = "USD";
            //decimal amount = 100m;
            (string, decimal) data = GetData("USD", 100);

            Price price = Price.Create(data.Item1, data.Item2);

            Assert.Equal(data.Item1, price.Code);
            Assert.Equal(data.Item2, price.Amount);
        }
        [Fact]
        public void Wrong_Currency_Code()
        {

            (string, decimal) data = GetData("COP", 1500);

            var exception = Assert.Throws<NotAllowedCurrencyException>(() => Price.Create(data.Item1,data.Item2));

            Assert.Equal($"{ErrorMessages.InvalidCurrency}. The currencies currently allowed are: USD, EUR, GBP, DOP", exception.Message);
            output.WriteLine(exception.Message);
            output.WriteLine("Hola");
        }

        private (string, decimal) GetData(string code, decimal price)
        {
            string _code = code;
            decimal _price = price;

            return (_code, _price);
        }
    }
}
