using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Users.Queries.GetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, BaseResponse<GetProfileQueryVM>>
    {
        private readonly IUserAppRepository _userAppRepository;
        private readonly IMapper _mapper;

        public GetProfileQueryHandler(IMapper mapper, IUserAppRepository userAppRepository)
        {
            _mapper = mapper;
            _userAppRepository = userAppRepository;
        }

        public async Task<BaseResponse<GetProfileQueryVM>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse<GetProfileQueryVM>("Błędne Id", false);

            var data = await _userAppRepository.GetUserByIdWithUserInfo(request.Id);

            if (data == null)
                return new BaseResponse<GetProfileQueryVM>("Nie ma użytkownika o takim id", false);

            return new BaseResponse<GetProfileQueryVM>(
                _mapper.Map<GetProfileQueryVM>(data));
        }
    }
}
