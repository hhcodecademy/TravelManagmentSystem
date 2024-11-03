using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TravelManagmentSystem.Application.Contracts.Repository;
using TravelManagmentSystem.Application.Contracts.Services.Auths;
using TravelManagmentSystem.Application.Contracts.Services.Users;
using TravelManagmentSystem.Application.Dtos;
using TravelManagmentSystem.Domain.Entities;
using TravelManagmentSystem.Infrastructure.Exceptions;
using TravelManagmentSystem.Infrastructure.Services.EmailOperations;
using TravelManagmentSystem.Infrastructure.Services.Users;

namespace TravelManagmentSystem.Infrastructure.Services.Auths
{
    public class AuthService(SignInManager<AppUser> _signInManager,
        UserManager<AppUser> _userManager, IMapper _mapper, IEmailService _emailService) : IAuthService
    {


        public async Task<string> SignInAsync(SignInDto signInDto)
        {
            var user = await _userManager.FindByNameAsync(signInDto.UserName);

            if (user == null) throw new BadRequestException("Username or password is wrong");


            var signInResult = await _signInManager.PasswordSignInAsync(user,
                                        signInDto.Password, signInDto.IsPersistent, false);

            if (!signInResult.Succeeded)
                throw new BadRequestException("Username or password is wrong");

            //TODO: 

            return "";

        }

        public async Task<UserResponseDto> SignUpAsync(SignUpDto signUpDto)
        {
            var user = await _userManager.FindByEmailAsync(signUpDto.Email);

            if (user != null) throw new BadRequestException("User already exist.");

            var result = await _userManager.CreateAsync(new AppUser
            {
                Email = signUpDto.Email,
                UserName = signUpDto.UserName,
            }, signUpDto.Password);

            if (!result.Succeeded) throw new BadRequestException();

            user = await _userManager.FindByEmailAsync(signUpDto.Email);

            var emailConfirmToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);


            var activationLink = $"https://localhost:7290/api/Auth/ConfirmEmail?email={signUpDto.Email}&token={emailConfirmToken}";

            await _emailService.SendEmailAsync(signUpDto.Email, "Confirm Your Email", $"Activate: {activationLink}");

            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task ConfirmEmailAsync(string email, string token)
        {

            token = token.Replace(" ", "+");

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) throw new BadRequestException();

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded) throw new BadRequestException();


        }
    }
}
