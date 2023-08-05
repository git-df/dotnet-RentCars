using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetCarDetails
{
    public class GetCarDetailsQueryHandler : IRequestHandler<GetCarDetailsQuery, BaseResponse<GetCarDetailsQueryVM>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public GetCarDetailsQueryHandler(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetCarDetailsQueryVM>> Handle(GetCarDetailsQuery request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse<GetCarDetailsQueryVM>("Błędne Id", false);

            var data = await _carRepository.GetCarById(request.Id);

            if (data == null)
                return new BaseResponse<GetCarDetailsQueryVM>("Brak samochodu z takim Id", false);

            return new BaseResponse<GetCarDetailsQueryVM>(
                _mapper.Map<GetCarDetailsQueryVM>(data));
        }
    }
}
