using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagmentSystem.Application.Dtos;

namespace TravelManagmentSystem.Application.Contracts.Services.Users
{
    public interface IUserService
    {
        Task<UserResponseDto> AddAsync(UserRequestDto dto);
        Task<UserResponseDto> UpdateAsync(Guid id, UserRequestDto dto);
        Task<UserResponseDto> GetAsync(Guid id);
        Task<IList<UserResponseDto>> GetAllAsync();
        Task<UserResponseDto> RemoveAsync(Guid id);
        Task<UserResponseDto> AssignRoleAsync(UserRoleDto userRoleDto); 
    }
}
