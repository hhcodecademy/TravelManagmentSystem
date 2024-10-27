using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TravelManagmentSystem.Domain.Configurations;

namespace TravelManagmentSystem.Domain.Entities
{
    [EntityTypeConfiguration(typeof(CustomerConfiguration))]
    public class Customer:Person
    {
        public string Nationality { get; set; }
        public bool IsHealty { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
