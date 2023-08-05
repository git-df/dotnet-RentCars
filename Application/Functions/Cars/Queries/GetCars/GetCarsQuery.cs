using Application.Functions.Common;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetCars
{
    public class GetCarsQuery : ListRequestOptions, IRequest<BaseResponse<List<GetCarsQueryVM>>>
    {
    }
}
