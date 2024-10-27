using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagmentSystem.Domain.Entities;

namespace TravelManagmentSystem.Domain.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Phone).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(100);
        }
    }
}
