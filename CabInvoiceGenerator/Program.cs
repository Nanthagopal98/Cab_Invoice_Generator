using System;
namespace CabInvoiceGenerator
{
    public class program
    {
        public static void Main(string[] args)
        {
            InvoiceGenerator GenerateInvoice = new InvoiceGenerator();
            Console.WriteLine("1 - Total Fare\n2 - Multiple Rides\n3 - Enhanced Invoice\n4 - Multiple User");
            int options = Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1:
                    {
                        double distance = 5;
                        int time = 5;
                        Ride ride = new Ride(distance, time);
                        double fare = GenerateInvoice.CalculateFare(ride);
                        Console.WriteLine("Total Fare : " + fare);
                        break;
                    }
                case 2:
                    {
                        Ride[] ride = { new Ride(5, 10), new Ride(10, 10), new Ride(5, 5) };
                        var fare = GenerateInvoice.InvoiceSummary(ride);
                        Console.WriteLine("Total Fare for Multiple Rides:" + fare.totalFare);
                        break;
                    }
                case 3:
                    {
                        Ride[] ride = { new Ride(5, 10), new Ride(10, 10), new Ride(5, 5) };
                        EnhancedInvoice invoice = GenerateInvoice.InvoiceSummary(ride);
                        break;
                    }
                case 4:
                    {
                        Ride[] rideNantha = { new Ride(5, 10), new Ride(10, 10), new Ride(5, 5) };
                        GenerateInvoice.AddRide("Nantha", rideNantha);
                        Ride[] rideEla = { new Ride(10, 10), new Ride(10, 10) };
                        GenerateInvoice.AddRide("Ela", rideEla);
                        GenerateInvoice.GetInvoice("Nantha");
                        GenerateInvoice.GetInvoice("Ela");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Enter a Valid Number");
                        break;
                    }
            }
        }
    }
}