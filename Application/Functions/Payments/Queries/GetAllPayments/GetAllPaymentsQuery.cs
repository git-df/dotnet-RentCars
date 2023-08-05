using Application.Functions.Common;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Payments.Queries.GetAllPayments
{
    public class GetAllPaymentsQuery : ListRequestOptions, IRequest<BaseResponse<List<GetAllPaymentsQueryVM>>>
    {
    }
}
