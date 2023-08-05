using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetBranchesWithOfferts
{
    public class GetBranchesWithOffertsQueryHandler : IRequestHandler<GetBranchesWithOffertsQuery, BaseResponse<List<GetBranchesWithOffertsQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;

        public GetBranchesWithOffertsQueryHandler(IMapper mapper, IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetBranchesWithOffertsQueryVM>>> Handle(GetBranchesWithOffertsQuery request, CancellationToken cancellationToken)
        {
            var data = await _branchRepository.GetBranchesWithOfferts();

            if (data == null || !data.Any())
                return new BaseResponse<List<GetBranchesWithOffertsQueryVM>>("Brak oddziałów", false);

            return new BaseResponse<List<GetBranchesWithOffertsQueryVM>>(
                _mapper.Map<List<GetBranchesWithOffertsQueryVM>>(data));
        }
    }
}
