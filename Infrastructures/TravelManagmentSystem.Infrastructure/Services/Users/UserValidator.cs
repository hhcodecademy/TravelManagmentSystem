using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagmentSystem.Application.Contracts.Services.Users;

namespace TravelManagmentSystem.Infrastructure.Services.Users
{
    public class UserValidator : AbstractValidator<UserRequestDto>
    {
        public UserValidator()
        {
            RuleFor(p => p).Must(p => p.Password == p.ConfirmPassword)
                .WithMessage("Password must be same with ConfirmPassword");
        }

    }
}
