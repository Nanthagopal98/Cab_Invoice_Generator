using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> rideRepo;
        public RideRepository()
            {
            this.rideRepo = new Dictionary<string, List<Ride>>();
            }
        public void AddRides(string userId, Ride[] rides)
        {
            bool rideList = this.rideRepo.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.rideRepo.Add(userId, list);
                }
            }
            catch (CustomExceptions)
            {
                throw new CustomExceptions(CustomExceptions.ExceptionTypes.NULL_RIDE, "Rides Are Null");
            }
        }
        public Ride[] GetRides(string userid)
        {
            try
            {
                return this.rideRepo[userid].ToArray();
            }
            catch(CustomExceptions)
            {
                throw new CustomExceptions(CustomExceptions.ExceptionTypes.INVALID_USER_ID, "Invalid UserID");
            }
        }
    }
}
