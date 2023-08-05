using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Queries.GetCarsToOffer
{
    internal class GetCarsToOfferQueryHandler : IRequestHandler<GetCarsToOfferQuery, BaseResponse<List<GetCarsToOfferQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public GetCarsToOfferQueryHandler(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetCarsToOfferQueryVM>>> Handle(GetCarsToOfferQuery request, CancellationToken cancellationToken)
        {
            var data = await _carRepository.GetCarsActive();

            if (data == null || !data.Any())
                return new BaseResponse<List<GetCarsToOfferQueryVM>>("Brak samochodów", false);

            return new BaseResponse<List<GetCarsToOfferQueryVM>>(
                _mapper.Map<List<GetCarsToOfferQueryVM>>(data));
        }
    }
}
