using CabInvoiceGenerator;
namespace CabInvoiceTest
{
    public class Tests
    {
        [Test]
        public void Given_Fare_When_Compare_Then_gives_Positive_Result()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();
            double result = invoice.CalculateFare(10, 10);
            int expected = 110;
            Assert.AreEqual(expected,result);
        }
    }
}