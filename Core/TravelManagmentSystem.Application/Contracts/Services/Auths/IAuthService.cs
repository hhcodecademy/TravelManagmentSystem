
using TravelManagmentSystem.Application.Dtos;

namespace TravelManagmentSystem.Application.Contracts.Services.Auths
{
    public interface IAuthService
    {
        Task<string> SignInAsync(SignInDto signInDto);
        Task<UserResponseDto> SignUpAsync(SignUpDto signInDto);
        Task ConfirmEmailAsync(string email, string token);
    }
}
