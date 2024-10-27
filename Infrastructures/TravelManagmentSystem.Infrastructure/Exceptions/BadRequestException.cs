using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagmentSystem.Infrastructure.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("Bad Request occured")
        {
        }
        public BadRequestException(string message) : base(message) { }
    }
}
