using Application.Contracts.Persistence;
using Application.Functions.Employes.Queries.GetBranchEmployes;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Queries.GetEmployesNoInBranch
{
    public class GetEmployesNoInBranchQueryHandler : IRequestHandler<GetEmployesNoInBranchQuery, BaseResponse<List<GetEmployesNoInBranchQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmployeeRepository _userEmployeeRepository;

        public GetEmployesNoInBranchQueryHandler(IMapper mapper, IUserEmployeeRepository userEmployeeRepository)
        {
            _userEmployeeRepository = userEmployeeRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetEmployesNoInBranchQueryVM>>> Handle(GetEmployesNoInBranchQuery request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse<List<GetEmployesNoInBranchQueryVM>>("Błędne Id", false);

            var data = await _userEmployeeRepository.GetEmployesByNoBranchId(request.Id, request.Page, request.PageSize, request.Search);

            if (!data.Any())
                return new BaseResponse<List<GetEmployesNoInBranchQueryVM>>("Brak pracowników do dodania", false);

            var dataCount = await _userEmployeeRepository.GetEmployesByNoBranchIdCount(request.Id, request.Search);

            return new BaseResponse<List<GetEmployesNoInBranchQueryVM>>(
                _mapper.Map<List<GetEmployesNoInBranchQueryVM>>(data), dataCount);
        }
    }
}
