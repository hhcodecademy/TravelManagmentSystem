using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;
using TravelManagmentSystem.Application.Contracts.Services;
using TravelManagmentSystem.Application.Contracts.Services.Auths;
using TravelManagmentSystem.Application.Contracts.Services.Users;
using TravelManagmentSystem.Infrastructure.Services;
using TravelManagmentSystem.Infrastructure.Services.Auths;
using TravelManagmentSystem.Infrastructure.Services.EmailOperations;
using TravelManagmentSystem.Infrastructure.Services.Users;

namespace TravelManagmentSystem.Infrastructure.Extensions
{
    public static class InfrastructureServices
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IEmailService , EmailService>();
            services.AddScoped<IAuthService , AuthService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(typeof(UserValidator));
        }
        public static void AddCustomSerilog(this ILoggingBuilder logBuilder)
        {
            var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(new ConfigurationBuilder()
            .AddJsonFile("serilog-config.json")
            .Build())
            .Enrich.FromLogContext()
            .CreateLogger();
            logBuilder.ClearProviders();
            logBuilder.AddSerilog(logger);
        }
    }
}
