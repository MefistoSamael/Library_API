using Library.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTCreatorController : ControllerBase
    {
        /// <summary>
        /// Gets JWT for program.
        /// </summary>
        /// <returns>JWT token</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/JWTCreator/
        ///
        /// </remarks>
        /// <response code="200">Returns the JWT token</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{username}")]
        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetBookByISBNAsync(string username)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}
