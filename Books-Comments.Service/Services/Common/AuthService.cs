using Books_Comments.Domain.Entities.Users;
using Books_Comments.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Books_Comments.Service.Services.Common;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    public AuthService(IConfiguration config)
    {
        _config = config.GetSection("Jwt");
    }
    public string GenerationToken(User user)
    {
        var claims = new[]
           {
                new Claim("Id", user.Id.ToString()),
                new Claim("Username", user.UserName),
                new Claim("ImagePath", (user.ImagePath is null)?"":user.ImagePath),
                new Claim(ClaimTypes.Email, user.Email),
            };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
            expires: DateTime.Now.AddMinutes(double.Parse(_config["Lifetime"])),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}