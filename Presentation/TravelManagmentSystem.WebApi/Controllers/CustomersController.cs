using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelManagmentSystem.Application.Contracts.Services;
using TravelManagmentSystem.Application.Dtos;

namespace TravelManagmentSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _customerService.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _customerService.GetAllAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CustomerDto dto)
        {
            var res = await _customerService.AddAsync(dto);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, CustomerDto dto)
        {
            var res = await _customerService.UpdateAsync(id, dto);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var res = await _customerService.RemoveAsync(id);
            return Ok(res);
        }
    }
}
