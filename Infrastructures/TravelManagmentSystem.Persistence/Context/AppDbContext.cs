using Microsoft.EntityFrameworkCore;
using TravelManagmentSystem.Domain.Entities;

namespace TravelManagmentSystem.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
