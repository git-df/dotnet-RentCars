using Application.Contracts.Persistence;
using Application.Functions.Attributes.Queries.GetCarAtributesByCar;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Attributes.Commands.RemoveCarAtribute
{
    public class RemoveCarAtributeHandler : IRequestHandler<RemoveCarAtributeCommand, BaseResponse>
    {
        private readonly ICarAttribureRepositoy _attribureRepositoy;

        public RemoveCarAtributeHandler(ICarAttribureRepositoy carAttribureRepositoy)
        {
            _attribureRepositoy = carAttribureRepositoy;
        }

        public async Task<BaseResponse> Handle(RemoveCarAtributeCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _attribureRepositoy.GetById(request.Id);

            if (data == null)
                return new BaseResponse("Brak atrybutu o takim id", false);

            await _attribureRepositoy.Delete(data);

            return new BaseResponse("Usunięto atybut");
        }
    }
}
