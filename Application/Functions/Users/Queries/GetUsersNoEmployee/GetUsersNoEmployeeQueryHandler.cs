using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Users.Queries.GetUsersNoEmployee
{
    public class GetUsersNoEmployeeQueryHandler : IRequestHandler<GetUsersNoEmployeeQuery, BaseResponse<List<GetUsersNoEmployeeQueryVM>>>
    {
        private readonly IUserAppRepository _userAppRepository;
        private readonly IMapper _mapper;

        public GetUsersNoEmployeeQueryHandler(IMapper mapper, IUserAppRepository userAppRepository)
        {
            _mapper = mapper;
            _userAppRepository = userAppRepository;
        }

        public async Task<BaseResponse<List<GetUsersNoEmployeeQueryVM>>> Handle(GetUsersNoEmployeeQuery request, CancellationToken cancellationToken)
        {
            var data = await _userAppRepository.GetUsersNoEmployes(request.Page, request.PageSize, request.Search);

            if (!data.Any())
                return new BaseResponse<List<GetUsersNoEmployeeQueryVM>>("Brak użytkowników", false);

            var dataCount = await _userAppRepository.GetUsersNoEmployesCount(request.Search);

            return new BaseResponse<List<GetUsersNoEmployeeQueryVM>>(
                _mapper.Map<List<GetUsersNoEmployeeQueryVM>>(data), dataCount);
        }
    }
}
