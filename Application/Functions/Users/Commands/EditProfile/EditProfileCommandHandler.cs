using Application.Contracts.Persistence;
using Application.Functions.Auth.Commands.SignUp;
using Application.Functions.Users.Queries.GetProfile;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Users.Commands.EditProfile
{
    public class EditProfileCommandHandler : IRequestHandler<EditProfileCommand, BaseResponse>
    {
        private readonly IUserAppRepository _userAppRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public EditProfileCommandHandler(IMapper mapper, IUserAppRepository userAppRepository, IUserInfoRepository userInfoRepository)
        {
            _mapper = mapper;
            _userAppRepository = userAppRepository;
            _userInfoRepository = userInfoRepository;
        }

        public async Task<BaseResponse> Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var validator = new EditProfileCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _userAppRepository.GetUserByIdWithUserInfo(request.Id);

            if (data == null)
                return new BaseResponse("Nie ma użytkownika o takim id", false);


            var useInfo = await _userInfoRepository.GetUserInfoByUserId(request.Id);

            if (useInfo == null)
            {
                useInfo = new UserInfo()
                {
                    FirstName = request.UserInfo.FirstName.ToLower(),
                    LastName = request.UserInfo.LastName.ToLower(),
                    PhoneNumber = request.UserInfo.PhoneNumber.ToUpper(),
                    PESEL = request.UserInfo.PESEL.ToUpper(),
                    DateOfBirth = request.UserInfo.DateOfBirth,
                    UserAppId = request.Id
                };

                await _userInfoRepository.Add(useInfo);

                return new BaseResponse("Dodano informacje użytkownika");
            }

            useInfo.FirstName = request.UserInfo.FirstName.ToLower();
            useInfo.LastName = request.UserInfo.LastName.ToLower();
            useInfo.PhoneNumber = request.UserInfo.PhoneNumber.ToUpper();
            useInfo.PESEL = request.UserInfo.PESEL.ToUpper();
            useInfo.DateOfBirth = request.UserInfo.DateOfBirth;

            await _userInfoRepository.Update(useInfo);

            return new BaseResponse("Zaktualizowano informacje użytkownika");
        }
    }
}
