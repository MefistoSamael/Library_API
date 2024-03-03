using Library.Application.Common.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTCreatorController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        
        public JWTCreatorController(IIdentityService identityService) 
        {
            _identityService = identityService;
        }
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
        
        public IActionResult GetBookByISBNAsync(string username)
        {
            var JWT = _identityService.GetJwtToken(username);
            
            return Ok(JWT);
        }
    }
}
