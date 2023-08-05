using Application.Contracts.Persistence;
using Application.Functions.Models.Queries.GetModelsList;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Attributes.Queries.GetCarAtributesByCar
{
    public class GetCarAtributesByCarQueryHandler : IRequestHandler<GetCarAtributesByCarQuery, BaseResponse<List<GetCarAtributesByCarQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly ICarAttribureRepositoy _attribureRepositoy;

        public GetCarAtributesByCarQueryHandler(IMapper mapper, ICarAttribureRepositoy attribureRepositoy)
        {
            _attribureRepositoy = attribureRepositoy;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetCarAtributesByCarQueryVM>>> Handle(GetCarAtributesByCarQuery request, CancellationToken cancellationToken)
        {
            if (!(request.CarId > 0))
                return new BaseResponse<List<GetCarAtributesByCarQueryVM>>("Błędne Id", false);

            var data = await _attribureRepositoy.GetCarAttributesByCarId(request.CarId);

            if (data == null || !data.Any())
                return new BaseResponse<List<GetCarAtributesByCarQueryVM>>("Brak atrybutów", false);

            return new BaseResponse<List<GetCarAtributesByCarQueryVM>>(
                _mapper.Map<List<GetCarAtributesByCarQueryVM>>(data), data.Count);
        }
    }
}
