using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MealMonkey.Api.Configurations
{
    public static class JwtAuthenticationExtensions
    {
        public static IServiceCollection AddAuthenticationConfig(
            this IServiceCollection services, IConfiguration configuration
            )
        {
            // Get JWT options from appsettings.json
            var jwtSettings = configuration.GetSection("JwtSettings");

            // Configure JWT options from appsettings.json
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
                    };
                });

            return services;
        }
    }

}