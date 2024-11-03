using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagmentSystem.Application.Dtos;

namespace TravelManagmentSystem.Application.Contracts.Services
{
    public interface IRoleService
    {
        Task<RoleDto> AddAsync(RoleDto dto);
        Task<RoleDto> UpdateAsync(Guid id, RoleDto dto);
        Task<RoleDto> GetAsync(Guid id);
        Task<IList<RoleDto>> GetAllAsync();
        Task<RoleDto> RemoveAsync(Guid id);
    }
}
