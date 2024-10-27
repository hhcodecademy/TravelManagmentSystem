using AutoMapper;
using TravelManagmentSystem.Application.Dtos;
using TravelManagmentSystem.Domain.Entities;

namespace TravelManagmentSystem.Application.Mapping
{
    public class CustomProfile:Profile
    {
        public CustomProfile()
        {
           CreateMap<CustomerDto,Customer>().ReverseMap();
        }
    }
}
