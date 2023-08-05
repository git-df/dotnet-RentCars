using Application.Contracts.Persistence;
using Application.Functions.Attributes.Commands.AddCarAtribute;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Attributes.Commands.EditCarAttribute
{
    public class EditCarAtributeCommandHandler : IRequestHandler<EditCarAtributeCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarAttribureRepositoy _attribureRepositoy;

        public EditCarAtributeCommandHandler(IMapper mapper, ICarAttribureRepositoy carAttribureRepositoy)
        {
            _attribureRepositoy = carAttribureRepositoy;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(EditCarAtributeCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            var validator = new EditCarAtributeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            var data = await _attribureRepositoy.GetById(request.Id);

            if (data == null)
                return new BaseResponse("Brak atrybutu z takim Id", false);

            data.Name = request.Name.ToUpper();
            data.Value = request.Value.ToUpper();

            await _attribureRepositoy.Update(data);

            return new BaseResponse("Zmieniono atrybut");
        }
    }
}
