using MealMonkey.Application.Services.Authantication;
using MealMonkey.Application.Services.Mailing;
using MealMonkey.Application.Services.ManageService;
using MealMonkey.Application.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MealMonkey.Api.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterCustomServises(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection(nameof(JWTSettings)));

            services.AddScoped<IAuthanticationService, AuthanticationService>();
            services.AddScoped<IManageService, ManageService>();
            services.AddScoped<IMailingService, MailingService>();

            return services;
        }
       
    }
}

