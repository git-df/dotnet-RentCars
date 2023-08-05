using Application.Contracts.Persistence;
using Application.Functions.Branches.Commands.AddBranch;
using Application.Functions.Cars.Queries.GetCarDetails;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Commands.AddCar
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, BaseResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly ICarModelRepository _carModelRepository;

        public AddCarCommandHandler(IMapper mapper, ICarRepository carRepository, ICarModelRepository carModelRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carModelRepository = carModelRepository;
        }

        public async Task<BaseResponse<int>> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            if (!(request.CarsModelId > 0))
                return new BaseResponse<int>("Błędne Id modelu", false);

            var validator = new AddCarCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse<int>(validationResult);

            var data = await _carModelRepository.GetById(request.CarsModelId);

            if (data == null)
                return new BaseResponse<int>("Brak modelu z takim Id", false);

            var newCar = await _carRepository.Add(
                _mapper.Map<Car>(request));

            if (!(newCar.Id > 0))
                return new BaseResponse<int>("Nie udało się dodać", false);

            return new BaseResponse<int>(newCar.Id);
        }
    }
}
