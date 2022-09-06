using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Backend.App.Interface;
using Backend.App.Models.DTO;

namespace Backend.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJwtAuthenticationService _authService;

        public TokenController(IJwtAuthenticationService auth)
        {

            _authService = auth;
        }

        /// <summary>
        /// metodo de autenticacion - genera token si usuario es correcto
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthInfo user)
        {
            var token = _authService.Authenticate(user.Username, user.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);

        }

    }
}
