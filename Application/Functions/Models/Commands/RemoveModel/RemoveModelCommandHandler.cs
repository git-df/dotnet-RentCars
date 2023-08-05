using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Models.Commands.RemoveModel
{
    public class RemoveModelCommandHandler : IRequestHandler<RemoveModelCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarModelRepository _carModelRepository;

        public RemoveModelCommandHandler(IMapper mapper, ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(RemoveModelCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _carModelRepository.GetByIdWithCars(request.Id);

            if (data == null)
                return new BaseResponse("Brak modelu z takim Id", false);

            if (data.Cars.Where(c => c.IsDeleted == false).Any())
                return new BaseResponse("Usuń najpierw samochody", false);

            data.IsDeleted = true;

            await _carModelRepository.Update(data);

            return new BaseResponse("Usunięto model");
        }
    }
}
