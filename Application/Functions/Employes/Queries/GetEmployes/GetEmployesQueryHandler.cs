using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Queries.GetEmployes
{
    public class GetEmployesQueryHandler : IRequestHandler<GetEmployesQuery, BaseResponse<List<GetEmployesQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmployeeRepository _userEmployeeRepository;

        public GetEmployesQueryHandler(IMapper mapper, IUserEmployeeRepository userEmployeeRepository)
        {
            _userEmployeeRepository = userEmployeeRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetEmployesQueryVM>>> Handle(GetEmployesQuery request, CancellationToken cancellationToken)
        {
            var data = await _userEmployeeRepository.GetEmployes(request.Page, request.PageSize, request.Search);

            if (!data.Any())
                return new BaseResponse<List<GetEmployesQueryVM>>("Brak pracowników", false);

            var dataCount = await _userEmployeeRepository.GetEmployesCount(request.Search);

            return new BaseResponse<List<GetEmployesQueryVM>>(
                _mapper.Map<List<GetEmployesQueryVM>>(data), dataCount);
        }
    }
}
