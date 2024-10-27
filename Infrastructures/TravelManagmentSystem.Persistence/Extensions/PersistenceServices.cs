using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagmentSystem.Application.Contracts.Repository;
using TravelManagmentSystem.Application.Contracts.UnitOfWorks;
using TravelManagmentSystem.Persistence.Context;
using TravelManagmentSystem.Persistence.Repository;
using TravelManagmentSystem.Persistence.UnitOfWorks;

namespace TravelManagmentSystem.Persistence.Extensions
{
    public static class PersistenceServices
    {
        public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("SQLConnectionString"));
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
