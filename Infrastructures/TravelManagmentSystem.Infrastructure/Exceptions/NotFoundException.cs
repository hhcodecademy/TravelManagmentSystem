using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagmentSystem.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Not Found Exception occured") { }

        public NotFoundException(string message) : base(message) { }

       
    }
}
