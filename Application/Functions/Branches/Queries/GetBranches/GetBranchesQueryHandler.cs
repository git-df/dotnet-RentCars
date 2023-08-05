using Application.Contracts.Persistence;
using Application.Functions.Branches.Queries.GetContacts;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Queries.GetBranches
{
    public class GetBranchesQueryHandler : IRequestHandler<GetBranchesQuery, BaseResponse<List<GetBranchesQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;

        public GetBranchesQueryHandler(IMapper mapper, IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetBranchesQueryVM>>> Handle(GetBranchesQuery request, CancellationToken cancellationToken)
        {
            var data = await _branchRepository.GetBranchesWithCountOfReferences(request.Page, request.PageSize, request.Search);

            if (data == null || !data.Any())
                return new BaseResponse<List<GetBranchesQueryVM>>("Brak oddziałów", false);

            var dataCount = await _branchRepository.GetSearchBranchesCount(request.Search);

            var responseData = new List<GetBranchesQueryVM>();


            foreach (var item in data)
            {
                responseData.Add(new GetBranchesQueryVM()
                {
                    Branch = _mapper.Map<BranchInGetBranchesQueryVM>(item),
                    EmployesCount = item.UserEmployee2Branches.Count,
                    OffersCount = item.Offers.Count
                });
            }

            return new BaseResponse<List<GetBranchesQueryVM>>(responseData, dataCount);
        }
    }
}
