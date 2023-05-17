using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutDoor_Models;
using OutDoor_Models.Models;
using OutDoor_Models.Requests.User;
using OutDoor_Models.Services;

namespace OutDoor_Backend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService UserService;

        public UserController(IUserService _userService)
        {
            UserService = _userService;
        }

        [HttpPost]
        [Route("/api/users")]
        public async Task<ActionResult> Create([FromBody] CreateUserRequest request)
        {
            var result = await UserService.CreateUser(request);

            return CreatedAtAction(nameof(Create), result);
        }

        [HttpPost]
        [Route("/api/users/login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await UserService.LoginUser(request);

            return Ok(result);
        }

        [HttpPut]
        [Route("/api/users")]
        public async Task<ActionResult> Edit([FromQuery] EditUserRequest request)
        {
            return Ok(await UserService.EditUserData(request));
        }
    }
}
