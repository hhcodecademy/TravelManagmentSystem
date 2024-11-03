using TravelManagmentSystem.Persistence.Extensions;
using TravelManagmentSystem.Infrastructure.Extensions;
using TravelManagmentSystem.WebApi.ExceptionHandlers;
using Microsoft.AspNetCore.Identity;
using TravelManagmentSystem.Persistence.Context;
using TravelManagmentSystem.Domain.Entities;
namespace TravelManagmentSystem.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructureService(builder.Configuration);
            builder.Services.AddPersistenceService(builder.Configuration);
            builder.Logging.AddCustomSerilog();

            builder.Services.AddIdentity<AppUser, AppRole>(opts =>
            {

                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequiredLength = 6;

            }).AddEntityFrameworkStores<AppDbContext>()
          .AddDefaultTokenProviders();
            builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
            builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


            builder.Services.AddProblemDetails();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
           
            app.UseExceptionHandler(_ =>{ });
           
            app.Run();
        }
    }
}
