using BubberDinner.Application.Common.Interface.Authentication;
using BubberDinner.Application.Common.Interface.Services;
using BubberDinner.Infrastructure.Services.Authentication;
using BubberDinner.Infrastructure.Services.DateTimeProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BubberDinner.Infrastructure.Configure.Authentication;
using BubberDinner.Application.Common.Interface.Persistent;
using BubberDinner.Infrastructure.Persistent;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
namespace BubberDinner.Infrastructure;

public static class Program
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddAuth(configuration);
        return services;
    }
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SECTION_NAME, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters =
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

        return services;
    }
}

