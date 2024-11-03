namespace TravelManagmentSystem.Application.Dtos;
public record UserResponseDto(Guid Id,string Name,string Surname,string UserName,
    string Email,List<string> RoleList = null);
