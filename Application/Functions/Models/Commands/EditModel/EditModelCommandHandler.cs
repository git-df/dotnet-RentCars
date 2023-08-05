using Application.Contracts.Persistence;
using Application.Functions.Branches.Commands.EditBranch;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Models.Commands.EditModel
{
    public class EditModelCommandHandler : IRequestHandler<EditModelCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarModelRepository _carModelRepository;

        public EditModelCommandHandler(IMapper mapper, ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(EditModelCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            var validator = new EditModelCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            var data = await _carModelRepository.GetById(request.Id);

            if (data == null)
                return new BaseResponse("Brak modelu z takim Id", false);

            data.BrandName = request.BrandName;
            data.ModelName = request.ModelName;

            await _carModelRepository.Update(data);

            return new BaseResponse("Model został edytowany");
        }
    }
}
