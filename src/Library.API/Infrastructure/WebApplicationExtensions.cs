using Library.Infrastructure.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;

namespace Template.Web.Infrastructure;

public static class WebApplicationExtensions
{
    public static WebApplication MapLogin(this WebApplication app)
    {
        app.Map("/login/{username}", (string username) =>
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        });

        return app;
    }
}
