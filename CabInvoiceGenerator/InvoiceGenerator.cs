using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private int MINIMUM_COST_PER_KM = 10;
        private int MINIMUM_FARE = 5;
        private int COST_PER_TIME = 1;
        double singleFare = 0;
        double totalFare = 0;
        public double CalculateFare(Ride ride)
        {
            try
            {
                singleFare = MINIMUM_COST_PER_KM * ride.distance + COST_PER_TIME * ride.time;
                if (singleFare <= 0)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionTypes.INVALID_INPUT, "Check Below Field");
                }
                Console.WriteLine("Curren Ride Fare : " + singleFare);
            }
            catch (CustomExceptions)
            {
                if (ride.distance <= 0)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionTypes.INVALID_DISTANCE, "Check Entered Distance");
                }
                if (ride.time < 0)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionTypes.INVALID_TIME, "Check Entered Time");
                }
            }
            return singleFare;
        }
        public double InvoiceSummary(Ride[] rides)
        {
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride);
                }
            }
            catch (CustomExceptions)
            {
                if (rides == null)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionTypes.NULL_RIDE, "Rides Are Null");
                }
            }
            Console.WriteLine("Total Fare For The Journey : " + totalFare);
            return totalFare;
        }
    }
}

