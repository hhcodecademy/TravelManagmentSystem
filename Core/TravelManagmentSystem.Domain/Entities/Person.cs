using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagmentSystem.Domain.Entities
{
    public abstract class Person:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
    }
}
