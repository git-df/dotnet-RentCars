using Application.Contracts.Persistence;
using Application.Functions.Offers.Queries.GetCarsToOffer;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Queries.GetBranchesToOffer
{
    public class GetBranchesToOfferQueryHandler : IRequestHandler<GetBranchesToOfferQuery, BaseResponse<List<GetBranchesToOfferQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;

        public GetBranchesToOfferQueryHandler(IMapper mapper, IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetBranchesToOfferQueryVM>>> Handle(GetBranchesToOfferQuery request, CancellationToken cancellationToken)
        {
            var data = await _branchRepository.GetBranchesWithAdresses();

            if (data == null || !data.Any())
                return new BaseResponse<List<GetBranchesToOfferQueryVM>>("Brak oddziałów", false);

            return new BaseResponse<List<GetBranchesToOfferQueryVM>>(
                _mapper.Map<List<GetBranchesToOfferQueryVM>>(data));
        }
    }
}
