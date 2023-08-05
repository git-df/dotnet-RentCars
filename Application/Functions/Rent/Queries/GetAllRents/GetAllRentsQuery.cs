using Application.Functions.Common;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetAllRents
{
    public class GetAllRentsQuery : ListRequestOptions, IRequest<BaseResponse<List<GetAllRentsQueryVM>>>
    {
    }
}
