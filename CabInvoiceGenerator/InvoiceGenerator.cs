using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideRepository rideRepository = new RideRepository();

        private int MINIMUM_COST_PER_KM;
        private int MINIMUM_FARE;
        private int COST_PER_TIME;
        public InvoiceGenerator(RideType rideType)
        {
            try
            {
                if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.MINIMUM_FARE = 5;
                    this.COST_PER_TIME = 1;
                }
                else if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.MINIMUM_FARE = 20;
                    this.COST_PER_TIME = 2;
                }
            }
            catch(CustomExceptions)
            {
                throw new CustomExceptions(CustomExceptions.ExceptionTypes.INVALID_RIDE_TYPE, "Check Ride Type");
            }    
        }
        public double CalculateFare(Ride ride)
        {
            double singleFare = 0;
            try
            {
                singleFare = MINIMUM_COST_PER_KM * ride.distance + COST_PER_TIME * ride.time;
                if (singleFare <= 0)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionTypes.INVALID_INPUT, "Check Below Field");
                }
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
        public EnhancedInvoice InvoiceSummary(Ride[] rides)
        {
            double totalFare = 0;
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
            return new EnhancedInvoice (rides.Length, totalFare);
        }
        public void AddRide(string userId, Ride[] rides)
        {
            rideRepository.AddRides(userId, rides);
        }
        public void GetInvoice(String userId)
        {           
            Console.WriteLine("UserId :"+userId);
            InvoiceSummary(rideRepository.GetRides(userId));
        }
    }
}

