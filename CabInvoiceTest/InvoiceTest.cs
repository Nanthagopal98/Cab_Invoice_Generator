using CabInvoiceGenerator;
namespace CabInvoiceTest
{
    public class Tests
    {      
        InvoiceGenerator invoice = new InvoiceGenerator();
        [Test]
        public void Given_Fare_When_Compare_Then_gives_Positive_Result()
        {
            Ride ride = new Ride(10, 10);
            double result = invoice.CalculateFare(ride);
            int expected = 110;
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Given_MultipleRide_When_Compare_Then_gives_Positive_Result()
        {
            int expected = 215;
            Ride[] ride = { new Ride(10, 10), new Ride(10, 5) };
            EnhancedInvoice result = invoice.InvoiceSummary(ride);
            Assert.AreEqual(expected, result.totalFare);
        }
        [Test]
        public void Given_MultipleRide_When_Compare_EnhancedInvoice_Then_gives_Positive_Result()
        {
            double expectedFare = 215;
            int expectedRides = 2;
            double expectedAverageFare = 107.5;
            Ride[] ride = { new Ride(10, 10), new Ride(10, 5) };
            EnhancedInvoice result = invoice.InvoiceSummary(ride);
            Assert.AreEqual(expectedFare, result.totalFare);
            Assert.AreEqual(expectedRides, result.numberOfRides);
            Assert.AreEqual(expectedAverageFare, result.averageFare);
        }
    }
}