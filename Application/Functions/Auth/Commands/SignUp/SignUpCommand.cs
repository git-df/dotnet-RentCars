using Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.SignUp
{
    public class SignUpCommand : IRequest<BaseResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserInfoInSignUpCommand UserInfo { get; set; }
    }

    public class UserInfoInSignUpCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string PESEL { get; set; }
    }
}
