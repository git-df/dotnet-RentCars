using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Attributes.Queries.GetCarAtributesByCar
{
    public class GetCarAtributesByCarQuery : IRequest<BaseResponse<List<GetCarAtributesByCarQueryVM>>>
    {
        public int CarId { get; set; }
    }
}
