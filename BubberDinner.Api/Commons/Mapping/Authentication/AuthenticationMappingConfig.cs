using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Commons.DTOs;
using BubberDinner.Application.Authentication.Queries.Login;
using BubberDinner.Contract.Authentication.Request;
using BubberDinner.Contract.Authentication.Response;
using Mapster;

namespace BubberDinner.Api.Commons.Mapping.Authentication;



public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
              .Map(destination => destination.Token, source => source.Token)
              .Map(destination => destination, source => source.User);
    }
}
