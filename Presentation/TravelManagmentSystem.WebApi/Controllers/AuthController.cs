using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelManagmentSystem.Application.Contracts.Services.Auths;

namespace TravelManagmentSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            await _authService.SignUpAsync(signUpDto);

            return Ok();
        }


        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string email, [FromQuery] string token)
        {
            await _authService.ConfirmEmailAsync(email, token);

            return Ok();
        }
    }
}
