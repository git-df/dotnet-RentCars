using Application.Responses;
using MediatR;

namespace Application.Functions.Auth.Commands.SignIn
{
    public class SignInCommand : IRequest<BaseResponse<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
