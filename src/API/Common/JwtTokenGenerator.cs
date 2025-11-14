using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Config;
using API.Requests;
using API.Responses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Common;

public class JwtTokenGenerator : ITokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }
    public TokenResponse Generate(GenerateTokenRequest request)
    {

        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Sub, request.Id),
            new (JwtRegisteredClaimNames.GivenName, request.FirstName),
            new (JwtRegisteredClaimNames.FamilyName, request.LastName),
            new (JwtRegisteredClaimNames.PreferredUsername, request.Username),
        };

        foreach (var role in request.Roles)
        {
            claims.Add(new(ClaimTypes.Role, role));
        }

        foreach (var permission in request.Permissions)
        {
            claims.Add(new("permission", permission));
        }

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                                (Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                                 SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateToken(descriptor);

        return new TokenResponse
        {
            AccessToken = tokenHandler.WriteToken(securityToken),
            Expires = descriptor.Expires,
            RefreshToken = "UkORAUshiAO6iZ6LRCAPS9LqmIYKM90Sac0/TYi9zSKpXLLv7/VYzRPwp1DydgP7sGhPFgm3M01HqtmcGQcYQ"
        };
    }

}

public interface ITokenGenerator
{
    public TokenResponse Generate(GenerateTokenRequest request);
}
