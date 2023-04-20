using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MealMonkey.Api.Configurations
{
    public static class DataPersistenceConfig
    {
        public static IServiceCollection ConfigurePersistence(
            this IServiceCollection services, IConfiguration configuration
            )
        {
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(Infrastructure.IAssemblyMarker).Assembly.GetName().Name);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 3);
                });
            });

            return services;
        }
    }
}