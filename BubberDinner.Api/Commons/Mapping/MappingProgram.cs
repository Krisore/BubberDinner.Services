using System.Reflection;
using Mapster;
using MapsterMapper;
namespace BubberDinner.Api.Commons.Mapping;
public static class MappingProgram
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());


        services.AddSingleton(config);
        services.AddScoped<IMapper, Mapper>();
        return services;
    }



}