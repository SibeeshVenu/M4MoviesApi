using System;
using System.Text;
using A4Auth.Api.Business.Interfaces;
using M4Movie.Api.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace A4Auth.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private static ITokenService _tokenService;
        private static IConfiguration _configuration;
        private static IUserService _userService;

        public AuthController(IConfiguration configuration,
            ITokenService tokenService,
            IUserService userService)
        {
            _tokenService = tokenService;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("token")]
        public IActionResult Token()
        {
            var header = Request.Headers["Authorization"];
            if (!header.ToString().StartsWith("Basic"))
                return BadRequest(504);
            var credential = header.ToString().Substring("Basic ".Length).Trim();
            var credData = Encoding.UTF8.GetString(Convert.FromBase64String(credential));
            var credValues = credData.Split(":");
            var userName = credValues[0];
            var userPassword = credValues[1];
            var strToken = _tokenService.GenerateToken(userName, _configuration["SignInKey"],
                _configuration["TokenIssuer"], _configuration["TokenAudience"]);
            return Ok(strToken);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (user == null) return BadRequest();
            try
            {
                if (_userService.GetUserByEmail(user.UserEmail) != null) return StatusCode(409, "Sorry, that mail id is not available");
                _userService.AddUser(user);
                return CreatedAtAction("register", user);
            }
            catch (Exception)
            {
                return BadRequest(500);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (user == null) return BadRequest();
            try
            {
                var existingUser = _userService.GetUserByEmail(user.UserEmail);
                if (existingUser == null) return NotFound(user);
                if (_userService.IsValidCredential(user.UserEmail, user.Password) == null) return BadRequest("Invalid Credentials");
                var token = _tokenService.GenerateToken(user.UserEmail, _configuration["SignInKey"],
                _configuration["TokenIssuer"], _configuration["TokenAudience"]);
                existingUser.CurrentToken = token;
                return Ok(existingUser);
            }
            catch (Exception)
            {
                return BadRequest(500);
            }
        }
    }
}