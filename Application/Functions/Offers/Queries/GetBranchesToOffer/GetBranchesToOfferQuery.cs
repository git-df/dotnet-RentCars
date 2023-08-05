using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Queries.GetBranchesToOffer
{
    public class GetBranchesToOfferQuery : IRequest<BaseResponse<List<GetBranchesToOfferQueryVM>>>
    {
    }
}
