using Application.Contracts.Persistence;
using Application.Functions.Cars.Queries.GetCarDetails;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Commands.RemoveCar
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public RemoveCarCommandHandler(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _carRepository.GetCarById(request.Id);

            if (data == null)
                return new BaseResponse("Brak samochodu z takim Id", false);

            data.IsDeleted = true;

            await _carRepository.Update(data);

            return new BaseResponse("Samochód został usunięty");
        }
    }
}
