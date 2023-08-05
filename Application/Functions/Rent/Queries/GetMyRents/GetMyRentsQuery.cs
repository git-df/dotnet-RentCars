using Application.Functions.Common;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetMyRents
{
    public class GetMyRentsQuery : ListRequestOptions, IRequest<BaseResponse<List<GetMyRentsQueryVM>>>
    {
        public int Id { get; set; }
    }
}
