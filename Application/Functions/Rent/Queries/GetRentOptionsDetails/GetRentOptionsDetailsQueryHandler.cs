using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetRentOptionsDetails
{
    public class GetRentOptionsDetailsQueryHandler : IRequestHandler<GetRentOptionsDetailsQuery, BaseResponse<GetRentOptionsDetailsQueryVM>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public GetRentOptionsDetailsQueryHandler(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetRentOptionsDetailsQueryVM>> Handle(GetRentOptionsDetailsQuery request, CancellationToken cancellationToken)
        {
            if (!(request.CarId >= 0))
                return new BaseResponse<GetRentOptionsDetailsQueryVM>("Błędne Id", false);

            var data = await _carRepository.GetRentOptionDetails(request.CarId, request.DateFrom, request.DateTo);

            if (data == null)
                return new BaseResponse<GetRentOptionsDetailsQueryVM>("Brak ofert", false);

            var response = _mapper.Map<GetRentOptionsDetailsQueryVM>(data);

            foreach (var item in response.Offers) 
            {
                item.Price = RentPriceCalcHandler.CalcPrice(request.DateFrom, request.DateTo, item.PricePerHour, item.PricePreDay);
            }

            return new BaseResponse<GetRentOptionsDetailsQueryVM>(response);
        }
    }
}
