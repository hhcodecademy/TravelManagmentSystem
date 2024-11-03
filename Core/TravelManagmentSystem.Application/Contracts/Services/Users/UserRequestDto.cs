namespace TravelManagmentSystem.Application.Contracts.Services.Users;
public record UserRequestDto(Guid Id, string Name, string Surname,
                            string UserName, string Email, string Password, string ConfirmPassword);
