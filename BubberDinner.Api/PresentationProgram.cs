using BubberDinner.Api.Commons.Errors;
using BubberDinner.Api.Commons.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BubberDinner.Api;

public static class PresentationProgram
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        {
            #region Pipeline
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            #endregion
        }
        return services;
    }
}