using Application.Functions.Common;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Payments.Queries.GetMyPayments
{
    public class GetMyPaymentsQuery : ListRequestOptions, IRequest<BaseResponse<List<GetMyPaymentsQueryVM>>>
    {
        public int Id { get; set; }
    }
}
