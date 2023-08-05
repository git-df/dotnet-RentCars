using Application.Contracts.Persistence;
using Application.Functions.Branches.Commands.AddBranch;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Models.Commands.AddModel
{
    public class AddModelCommandHandler : IRequestHandler<AddModelCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarModelRepository _carModelRepository;

        public AddModelCommandHandler(IMapper mapper, ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddModelCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddModelCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            var data = await _carModelRepository.Add(
                _mapper.Map<CarsModel>(request));

            if (data == null || !(data.Id > 0))
                return new BaseResponse("Nie udało się dodać modelu", false);

            return new BaseResponse("Model został dodany");
        }
    }
}
