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
        double totalFare = 0;
        public void CalculateFare(double distance, double time)
        {
            try
            {
                totalFare = MINIMUM_COST_PER_KM * distance + COST_PER_TIME * time;
                if (totalFare <= 0)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionTypes.INVALID_INPUT, "Check Below Field");
                }
                Console.WriteLine("Total Fare For The Journey : " + totalFare);
            }
            catch(CustomExceptions)
            {
                if(distance <= 0)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionTypes.INVALID_DISTANCE, "Check Entered Distance");
                }
                if(time<0)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionTypes.INVALID_TIME, "Check Entered Time");
                }
            }
        }
    }
}
