using System;
namespace CabInvoiceGenerator
{
    public class program
    {
        public static void Main(string[] args)
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] ride = { new Ride(10, 10), new Ride(10, 5) };
            //EnhancedInvoice result = invoice.InvoiceSummary(ride);
            invoiceGenerator.InvoiceSummary(ride);
        }
    }
}