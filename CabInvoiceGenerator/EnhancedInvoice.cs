using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class EnhancedInvoice
    {
        public int numberOfRides;
        public double totalFare;
        public double averageFare;
        public EnhancedInvoice(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = totalFare / numberOfRides;
            Console.WriteLine("Number of Rides : "+numberOfRides +"\nTotal Fare : "+totalFare +"\nAverage Fare : "+averageFare);
        }

    }
}
