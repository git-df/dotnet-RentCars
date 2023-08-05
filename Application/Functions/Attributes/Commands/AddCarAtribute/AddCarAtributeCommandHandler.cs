using Application.Contracts.Persistence;
using Application.Functions.Cars.Commands.AddCar;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Attributes.Commands.AddCarAtribute
{
    public class AddCarAtributeCommandHandler : IRequestHandler<AddCarAtributeCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarAttribureRepositoy _attribureRepositoy;
        private readonly ICarRepository _carRepository;

        public AddCarAtributeCommandHandler(ICarAttribureRepositoy carAttribureRepositoy, ICarRepository carRepository, IMapper mapper)
        {
            _attribureRepositoy = carAttribureRepositoy;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddCarAtributeCommand request, CancellationToken cancellationToken)
        {
            if (!(request.CarId > 0))
                return new BaseResponse("Błędne Id", false);

            var validator = new AddCarAtributeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            var data = await _carRepository.GetById(request.CarId);

            if (data == null)
                return new BaseResponse("Brak samochodu z takim Id", false);

            request.Value = request.Value.ToUpper();
            request.Name = request.Name.ToUpper();

            var newAttribute = await _attribureRepositoy.Add(
                _mapper.Map<CarAttribute>(request));

            if (!(newAttribute.Id > 0))
                return new BaseResponse("Nie udało się dodać", false);

            return new BaseResponse("Dodano atrybut");
        }
    }
}
