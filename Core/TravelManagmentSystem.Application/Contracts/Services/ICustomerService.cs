
using TravelManagmentSystem.Application.Dtos;

namespace TravelManagmentSystem.Application.Contracts.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> AddAsync(CustomerDto dto);
        Task<CustomerDto> UpdateAsync(Guid id, CustomerDto dto);
        Task<CustomerDto> GetAsync(Guid id);
        Task<IList<CustomerDto>> GetAllAsync();
        Task<CustomerDto> RemoveAsync(Guid id);
    }
}
