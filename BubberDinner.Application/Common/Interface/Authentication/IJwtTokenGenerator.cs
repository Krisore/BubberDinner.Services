

namespace BubberDinner.Application.Common.Interface.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid usesrId, string firstname, string lastName, string Email, string password);
    string GenerateToken(Guid usesrId, string firstname, string lastName);
}
