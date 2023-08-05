using Application.Contracts.Persistence;
using Application.Functions.Cars.Commands.AddCar;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Commands.EditCar
{
    public class EditCarCommandHandler : IRequestHandler<EditCarCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public EditCarCommandHandler(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(EditCarCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            var validator = new EditCarCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            var data = await _carRepository.GetCarById(request.Id);

            if (data == null)
                return new BaseResponse("Brak samochodu z takim Id", false);

            data.Year = request.Year;
            data.PlaceNumber = request.PlaceNumber;
            data.VIN = request.VIN;
            data.Fuel = request.Fuel;
            data.Image = request.Image;

            await _carRepository.Update(data);

            return new BaseResponse("Zaktualizowano samochód");
        }
    }
}

