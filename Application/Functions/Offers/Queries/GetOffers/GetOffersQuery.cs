using Application.Functions.Common;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Queries.GetOffers
{
    public class GetOffersQuery : ListRequestOptions, IRequest<BaseResponse<List<GetOffersQueryVM>>>
    {
    }
}
