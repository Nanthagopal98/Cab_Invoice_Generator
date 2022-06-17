using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CustomExceptions : Exception
    {
        public enum ExceptionTypes
        {
            INVALID_DISTANCE,INVALID_TIME,INVALID_INPUT, NULL_RIDE, INVALID_USER_ID, INVALID_RIDE_TYPE
        }
        public ExceptionTypes type;
        public CustomExceptions(ExceptionTypes type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
