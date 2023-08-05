using Application.Contracts.Persistence;
using Application.Functions.Branches.Queries.GetBranchDetails;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Queries.GetBranchEmployes
{
    public class GetBranchEmployesQueryHandler : IRequestHandler<GetBranchEmployesQuery, BaseResponse<List<GetBranchEmployesQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmployeeRepository _userEmployeeRepository;

        public GetBranchEmployesQueryHandler(IMapper mapper, IUserEmployeeRepository userEmployeeRepository)
        {
            _userEmployeeRepository = userEmployeeRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetBranchEmployesQueryVM>>> Handle(GetBranchEmployesQuery request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse<List<GetBranchEmployesQueryVM>>("Błędne Id", false);

            var data = await _userEmployeeRepository.GetEmployesByBranchId(request.Id, request.Page, request.PageSize, request.Search);

            if (!data.Any())
                return new BaseResponse<List<GetBranchEmployesQueryVM>>("Brak pracowników w tym oddziale", false);

            var dataCount = await _userEmployeeRepository.GetEmployesByBranchIdCount(request.Id, request.Search);

            return new BaseResponse<List<GetBranchEmployesQueryVM>>(
                _mapper.Map<List<GetBranchEmployesQueryVM>>(data), dataCount);
        }
    }
}
