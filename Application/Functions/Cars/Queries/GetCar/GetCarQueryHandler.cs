using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetCar
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, BaseResponse<GetCarQueryVM>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public GetCarQueryHandler(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetCarQueryVM>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            if (!(request.CarId > 0))
                return new BaseResponse<GetCarQueryVM>("Błędne Id", false);

            var data = await _carRepository.GetCar(request.CarId);

            if (data == null)
                return new BaseResponse<GetCarQueryVM>("Brak samochodu z takim Id", false);

            return new BaseResponse<GetCarQueryVM>(
                _mapper.Map<GetCarQueryVM>(data));
        }
    }
}
