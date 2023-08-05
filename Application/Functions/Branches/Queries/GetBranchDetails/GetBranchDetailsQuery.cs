using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Queries.GetBranchDetails
{
    public class GetBranchDetailsQuery : IRequest<BaseResponse<GetBranchDetailsQueryVM>>
    {
        public int Id { get; set; }
    }
}
