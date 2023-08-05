using Application.Contracts.Persistence;
using Application.Functions.Branches.Queries.GetBranches;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Queries.GetBranchDetails
{
    public class GetBranchDetailsQueryHandler : IRequestHandler<GetBranchDetailsQuery, BaseResponse<GetBranchDetailsQueryVM>>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;

        public GetBranchDetailsQueryHandler(IMapper mapper, IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetBranchDetailsQueryVM>> Handle(GetBranchDetailsQuery request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse<GetBranchDetailsQueryVM>("Błędne Id", false);
            
            var data = await _branchRepository.GetBranchByIdWithAddress(request.Id);

            if (data == null)
                return new BaseResponse<GetBranchDetailsQueryVM>("Brak oddziału z takim Id", false);

            return new BaseResponse<GetBranchDetailsQueryVM>(
                _mapper.Map<GetBranchDetailsQueryVM>(data));
        }
    }
}
