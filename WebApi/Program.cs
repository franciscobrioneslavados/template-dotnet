using System.Globalization;
using Application.UseCases.AddCustomer;
using Domain.Contracts.Repositories.AddCustomer;
using Domain.Contracts.UseCases.AddCustomer;
using FluentValidation;
using Infra.Repository.Repositories.AddCutomer;
using WebApi.Models.AddCustomer;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IAddCustomerRepository, AddCustomerRepository>();
            builder.Services.AddScoped<IAddCustomerUseCase, AddCustomerUseCase>();
            builder.Services.AddTransient<IValidator<AddCustomerInput>, AddCustomerInputValidator>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // builder.Configuration.AddJsonFile("appsettings.json");
            // builder.Configuration.AddJsonFile("appsettings.{env.EnvironmentName}.json");
            // builder.Configuration.AddEnvironmentVariables();
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

            var cultureInfo = new CultureInfo("es-ES");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.Run();

        }
    }
}
