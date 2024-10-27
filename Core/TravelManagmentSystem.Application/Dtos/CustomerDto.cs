

namespace TravelManagmentSystem.Application.Dtos;

public record CustomerDto(Guid Id,string Name,string Surname, string Nationality,bool IsHealty,string Email, string Phone);

