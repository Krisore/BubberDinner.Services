using BubberDinner.Application.Common.Interface.Authentication;
using BubberDinner.Application.Common.Interface.Services;
using BubberDinner.Infrastructure.Services.Authentication;
using BubberDinner.Infrastructure.Services.DateTimeProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using BubberDinner.Infrastructure.Configure.Authentication;
namespace BubberDinner.Infrastructure;

public static  class Program
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(options =>
        {
            configuration.GetSection(JwtSettings.SECTION_NAME).Bind(options);
        });
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}
