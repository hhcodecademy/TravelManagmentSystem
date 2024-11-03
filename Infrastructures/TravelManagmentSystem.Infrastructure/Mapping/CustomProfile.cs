using AutoMapper;
using TravelManagmentSystem.Application.Contracts.Services.Auths;
using TravelManagmentSystem.Application.Contracts.Services.Users;
using TravelManagmentSystem.Application.Dtos;
using TravelManagmentSystem.Domain.Entities;

namespace TravelManagmentSystem.Application.Mapping
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<UserRequestDto, AppUser>();
            CreateMap<AppUser, UserResponseDto>();
            CreateMap<SignUpDto, AppUser>();
            CreateMap<RoleDto, AppRole>().ReverseMap();
        }
    }
}
