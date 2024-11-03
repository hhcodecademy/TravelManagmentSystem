using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagmentSystem.Application.Contracts.Repository;
using TravelManagmentSystem.Application.Contracts.Services;
using TravelManagmentSystem.Application.Contracts.UnitOfWorks;
using TravelManagmentSystem.Application.Dtos;
using TravelManagmentSystem.Domain.Entities;
using TravelManagmentSystem.Infrastructure.Exceptions;

namespace TravelManagmentSystem.Infrastructure.Services
{
    public class RoleService(RoleManager<AppRole> _roleManager,
        IMapper _mapper
        ) : IRoleService
    {
        public async Task<RoleDto> AddAsync(RoleDto dto)
        {
            var entity = _mapper.Map<AppRole>(dto);
            await _roleManager.CreateAsync(entity);

            return _mapper.Map<RoleDto>(entity);
        }

        public async Task<IList<RoleDto>> GetAllAsync()
        {
            var query = _roleManager.Roles;
            var entities = await query.ToListAsync();
            return _mapper.Map<IList<RoleDto>>(entities);
        }

        public async Task<RoleDto> GetAsync(Guid id)
        {
            var entity = await _roleManager.FindByIdAsync(id.ToString());
            return _mapper.Map<RoleDto>(entity);
        }

        public async Task<RoleDto> RemoveAsync(Guid id)
        {
            var entity = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(entity);
            return _mapper.Map<RoleDto>(entity);
        }

        public async Task<RoleDto> UpdateAsync(Guid id, RoleDto dto)
        {
            var entity = await _roleManager.FindByIdAsync(id.ToString());
            if (entity is null)
            {
                throw new NotFoundException($"This {id} is not found");
            }
            await _roleManager.UpdateAsync(entity);
            var updatedDto = _mapper.Map<RoleDto>(entity);
            return updatedDto;
        }
    }
}
