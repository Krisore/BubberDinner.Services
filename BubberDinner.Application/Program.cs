
using System.Reflection;
using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Commons.DTOs;
using BubberDinner.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BubberDinner.Application;

public static class Program
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Program).Assembly));

        #region PipelineBehavior
        {
            services.AddScoped
            (
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>)
            );


        }
        #endregion

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }


}