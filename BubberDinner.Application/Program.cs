
using Microsoft.Extensions.DependencyInjection;

namespace BubberDinner.Application;

public static class Program
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Program).Assembly));
        return services;
    }


}