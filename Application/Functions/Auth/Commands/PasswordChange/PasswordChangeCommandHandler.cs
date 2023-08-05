using Application.Contracts.Persistence;
using Application.Functions.Auth.Commands.SignIn;
using Application.Functions.Employes.Queries.GetBranchEmployes;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.PasswordChange
{
    public class PasswordChangeCommandHandler : IRequestHandler<PasswordChangeCommand, BaseResponse>
    {
        private readonly IUserAppRepository _userAppRepository;

        public PasswordChangeCommandHandler(IUserAppRepository userAppRepository)
        {
            _userAppRepository = userAppRepository;
        }

        public async Task<BaseResponse> Handle(PasswordChangeCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            var validator = new PasswordChangeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            var data = await _userAppRepository.GetById(request.Id);

            if (data == null)
                return new BaseResponse("Nie ma użytkownika o takim id", false);

            if (AuthPasswordHashHandler.HashPassword(request.OldPassword, data.Salt) != data.Password)
                return new BaseResponse("Złe obecne hasło", false);

            data.Salt = AuthPasswordHashHandler.SaltGenerator();
            data.Password = AuthPasswordHashHandler.HashPassword(request.NewPassword, data.Salt);

            await _userAppRepository.Update(data);

            return new BaseResponse("Zmieniono hasło");
        }
    }
}
