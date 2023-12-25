

using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Common.Interface.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
