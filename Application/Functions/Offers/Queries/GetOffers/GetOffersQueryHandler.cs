using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Queries.GetOffers
{
    public class GetOffersQueryHandler : IRequestHandler<GetOffersQuery, BaseResponse<List<GetOffersQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;

        public GetOffersQueryHandler(IMapper mapper, IOfferRepository offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<BaseResponse<List<GetOffersQueryVM>>> Handle(GetOffersQuery request, CancellationToken cancellationToken)
        {
            var data = await _offerRepository.GetOffers(request.Page, request.PageSize, request.Search);

            if (data == null || !data.Any())
                return new BaseResponse<List<GetOffersQueryVM>>("Brak ofert", false);

            var dataCount = await _offerRepository.GetOffersCount(request.Search);

            return new BaseResponse<List<GetOffersQueryVM>>(
                _mapper.Map<List<GetOffersQueryVM>>(data), dataCount);
        }
    }
}
