using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelManagmentSystem.Application.Contracts.Services;
using TravelManagmentSystem.Application.Dtos;

namespace TravelManagmentSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService _roleService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _roleService.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _roleService.GetAllAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(RoleDto dto)
        {
            var res = await _roleService.AddAsync(dto);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, RoleDto dto)
        {
            var res = await _roleService.UpdateAsync(id, dto);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var res = await _roleService.RemoveAsync(id);
            return Ok(res);
        }
    }
}
