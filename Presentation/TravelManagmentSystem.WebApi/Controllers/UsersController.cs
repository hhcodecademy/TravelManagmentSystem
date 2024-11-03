using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelManagmentSystem.Application.Contracts.Services.Users;

namespace TravelManagmentSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService _userService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _userService.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserRequestDto dto)
        {
            var res = await _userService.AddAsync(dto);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, UserRequestDto dto)
        {
            var res = await _userService.UpdateAsync(id, dto);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var res = await _userService.RemoveAsync(id);
            return Ok(res);
        }
        [HttpPost("assignRole")]
        public async Task<IActionResult> AssignRole(UserRoleDto userRoleDto)
        {
            var response = await _userService.AssignRoleAsync(userRoleDto);
            return Ok(response);
        }
    }
}
