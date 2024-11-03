using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelManagmentSystem.Domain.Entities;

namespace TravelManagmentSystem.Persistence.Context
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
