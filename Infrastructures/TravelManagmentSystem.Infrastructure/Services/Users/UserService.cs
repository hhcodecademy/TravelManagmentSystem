using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelManagmentSystem.Application.Contracts.Services.Users;
using TravelManagmentSystem.Application.Dtos;
using TravelManagmentSystem.Domain.Entities;
using TravelManagmentSystem.Infrastructure.Exceptions;

namespace TravelManagmentSystem.Infrastructure.Services.Users
{
    public class UserService(UserManager<AppUser> _userManager,
        RoleManager<AppRole> _roleManager,
        IMapper _mapper
        ) : IUserService
    {
        public async Task<UserResponseDto> AddAsync(UserRequestDto dto)
        {
            var entity = _mapper.Map<AppUser>(dto);
            await _userManager.CreateAsync(entity, dto.Password);
            var userDto = _mapper.Map<UserResponseDto>(entity);

            return userDto;
        }

        public async Task<IList<UserResponseDto>> GetAllAsync()
        {
            var query = _userManager.Users;
            var entities = await query.ToListAsync();
            return _mapper.Map<IList<UserResponseDto>>(entities);
        }

        public async Task<UserResponseDto> GetAsync(Guid id)
        {
            var entity = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<UserResponseDto>(entity);
        }

        public async Task<UserResponseDto> RemoveAsync(Guid id)
        {
            var entity = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(entity);
            return _mapper.Map<UserResponseDto>(entity);
        }

        public async Task<UserResponseDto> UpdateAsync(Guid id, UserRequestDto dto)
        {
            var entity = await _userManager.FindByIdAsync(id.ToString());
            if (entity is null)
            {
                throw new NotFoundException($"This {id} is not found");
            }
            await _userManager.UpdateAsync(entity);
            var updatedDto = _mapper.Map<UserResponseDto>(entity);
            return updatedDto;
        }
        public async Task<UserResponseDto> AssignRoleAsync(UserRoleDto userRoleDto)
        {
            var user = await _userManager.FindByIdAsync(userRoleDto.UserId.ToString());

            if (user is null) throw new NotFoundException("User not found");
            var role = await _roleManager.FindByNameAsync(userRoleDto.RoleName);
            if (role is null) throw new NotFoundException("Role not found");
            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (!result.Succeeded)
            {
                throw new BadRequestException();
            }

            var dto = _mapper.Map<UserResponseDto>(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            dto.RoleList.AddRange(userRoles);

            return dto;
        }
    }
}
