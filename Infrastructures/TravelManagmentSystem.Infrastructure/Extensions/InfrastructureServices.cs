using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TravelManagmentSystem.Application.Contracts.Services;
using TravelManagmentSystem.Infrastructure.Services;

namespace TravelManagmentSystem.Infrastructure.Extensions
{
    public static class InfrastructureServices
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
