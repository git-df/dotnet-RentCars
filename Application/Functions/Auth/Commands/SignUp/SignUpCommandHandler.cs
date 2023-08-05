using Application.Contracts.Persistence;
using Application.Functions.Auth.Commands.SignIn;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, BaseResponse>
    {
        private readonly IUserAppRepository _userAppRepository;
        private readonly IMapper _mapper;

        public SignUpCommandHandler(IMapper mapper, IUserAppRepository userAppRepository)
        {
            _mapper = mapper;
            _userAppRepository = userAppRepository;

        }

        public async Task<BaseResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var validator = new SignUpCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            var user = await _userAppRepository.GetUserByEmail(request.Email.ToLower());

            if (user != null)
                return new BaseResponse("Użytkownik z takim emailem już istnieje", false);

            var salt = AuthPasswordHashHandler.SaltGenerator();
            var newUser = _mapper.Map<UserApp>(request);

            newUser.Salt = salt;
            newUser.Password = AuthPasswordHashHandler.HashPassword(request.Password, salt);
            newUser.Email = request.Email.ToLower();
            newUser.UserInfo.FirstName = request.UserInfo.FirstName.ToLower();
            newUser.UserInfo.LastName = request.UserInfo.LastName.ToLower();
            newUser.UserInfo.PESEL = request.UserInfo.PESEL.ToUpper();
            newUser.UserInfo.PhoneNumber = request.UserInfo.PhoneNumber.ToUpper();


            var response = await _userAppRepository.Add(newUser);

            if (response != null)
                return new BaseResponse("Dodano użytkownika");

            return new BaseResponse(false);
        }
    }
}
