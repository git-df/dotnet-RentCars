using Application.Functions.Common;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetCarsByModel
{
    public class GetCarsByModelQuery : ListRequestOptions, IRequest<BaseResponse<List<GetCarsByModelQueryVM>>>
    {
        public int ModelId { get; set; }
    }
}
