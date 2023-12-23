using BubberDinner.Application.Common.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using BubberDinner.Application.Common.Interface.Services;
using Microsoft.Extensions.Options;
using BubberDinner.Infrastructure.Configure.Authentication;
namespace BubberDinner.Infrastructure.Services.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtSettings.Value;
        }
        public string GenerateToken(Guid usesrId, string firstname, string lastName, string Email, string password)
        {
            throw new NotImplementedException();
        }
        public string GenerateToken(Guid usesrId, string firstname, string lastName)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, firstname + "" + lastName),
                new Claim(JwtRegisteredClaimNames.GivenName, firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var signingCredentials = new SigningCredentials
            (
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256
            );
            var securityToken = new JwtSecurityToken
            (
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                claims: claims,
                signingCredentials: signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
