using Cinemanjaro.Users.API.DTOs;
using Cinemanjaro.Users.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cinemanjaro.Users.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        [SwaggerOperation("Creates account for user")]
        public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
        {
            await _usersService.RegisterUser(registerDto.Email, registerDto.Password);
            
            return Ok();
        }

        [HttpPost("login")]
        [SwaggerOperation("Returns bearer token for user")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _usersService.Login(loginDto.Email, loginDto.Password);

            return Ok(token);
        }
    }
}
