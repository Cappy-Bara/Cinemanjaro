using Cinemanjaro.Users.API.DTOs;
using Cinemanjaro.Users.Core.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
        {
            await _usersService.RegisterUser(registerDto.Email, registerDto.Password);
            
            return Ok();
        }

    }
}
