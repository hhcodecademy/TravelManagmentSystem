using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagmentSystem.Application.Contracts.Services.Auths
{
    public record SignInDto(string UserName, string Password, bool IsPersistent);
}
