using Application.Functions.Auth.Commands.PasswordChange;
using Application.Functions.Auth.Commands.SignIn;
using Application.Functions.Auth.Commands.SignUp;
using Application.Responses;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<BaseResponse<string>> SignIn([FromBody] SignInCommand request)
        {
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<BaseResponse> SignUp([FromBody] SignUpCommand request)
        {
            return await _mediator.Send(request);
        }

        [Authorize]
        [HttpPatch]
        public async Task<BaseResponse> PasswordChange([FromBody] PasswordChangeCommand request)
        {
            string stringClaimId = (HttpContext.User.Identity as ClaimsIdentity)?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";

            request.SetId(Int32.Parse(stringClaimId));

            return await _mediator.Send(request);
        }

        [Authorize]
        [HttpGet]
        public BaseResponse<GetUserAuthInfoVM> GetUserAuthInfo()
        {
            var claims = (HttpContext.User.Identity as ClaimsIdentity)?.Claims.ToList() ?? new List<Claim>();

            if (claims.Exists(c => c.Type == ClaimTypes.NameIdentifier) &&
                claims.Exists(c => c.Type == ClaimTypes.Email) &&
                claims.Exists(c => c.Type == ClaimTypes.GivenName) &&
                claims.Exists(c => c.Type == ClaimTypes.Surname) &&
                claims.Exists(c => c.Type == ClaimTypes.Role)) 
            {
                return new BaseResponse<GetUserAuthInfoVM>(
                    new GetUserAuthInfoVM()
                    {
                        Id = Int32.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0"),
                        Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? "null",
                        FirstName = claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value ?? "null",
                        LastName = claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value ?? "null",
                        Role = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "null",
                    });
            }

            return new BaseResponse<GetUserAuthInfoVM>("Błąd użytkownika", false);
        }

        public class GetUserAuthInfoVM
        {
            public int Id { get; set; }
            public string Email { get; set; } = string.Empty;
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
        }
    }
}
