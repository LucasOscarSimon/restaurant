using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Restaurant.Application;
using Restaurant.Application.Services;
using Restaurant.Domain.Repository;
using Restaurant.Infra.Data;
using Restaurant.Infra.Data.Repository;

namespace Restaurant.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderAppServiceFactory, OrderAppServiceFactory>();
            services.AddScoped<IDishRepository, DishRepository>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Restaurant 1.0 - ORDERS",
                    Description = "API Restaurant 1.0 - ORDERS",
                    Contact = new OpenApiContact
                    {
                        Name = "Restaurant 1.0 - ORDERS",
                        Email = string.Empty,
                    }
                });
            });
        }

        public static void ConfigureEfCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DishContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(DishContext).Assembly.FullName)));
        }
    }
}