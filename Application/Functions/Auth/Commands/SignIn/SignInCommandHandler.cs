using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, BaseResponse<string>>
    {
        private readonly IUserAppRepository _userAppRepository;
        private readonly IConfiguration _configuration;

        public SignInCommandHandler(IConfiguration configuration, IUserAppRepository userAppRepository)
        {
            _configuration = configuration;
            _userAppRepository = userAppRepository;

        }

        public async Task<BaseResponse<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var validator = new SignInCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse<string>(validationResult);

            var user = await _userAppRepository.GetUserByEmail(request.Email.ToLower());

            if (user == null)
                return new BaseResponse<string>("Nie ma takiego użytkownika", false);

            if(AuthPasswordHashHandler.HashPassword(request.Password, user.Salt) != user.Password)
                return new BaseResponse<string>("Złe hasło", false);

            var token = Generate(user);

            if (token == null)
                return new BaseResponse<string>("Problem z kontem użytkownika", false);

            return new BaseResponse<string>(token, "Poprawnie zalogowano");
        }

        private string Generate(UserApp user)
        {
            string role = "";

            if (user == null || user.UserInfo == null)
                return null;


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creditials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            if (user.UserEmployee != null)
            {
                if (user.UserEmployee.IsAdmin)
                {
                    role = "Admin";
                }
                else
                {
                    role = "Employee";
                }
            }
            else
            {
                role = "Customer";
            }


            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.UserInfo.FirstName),
                new Claim(ClaimTypes.Surname, user.UserInfo.LastName),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: creditials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
