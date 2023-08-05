using Application.Functions.Common;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Queries.GetBranchEmployes
{
    public class GetBranchEmployesQuery : ListRequestOptions, IRequest<BaseResponse<List<GetBranchEmployesQueryVM>>>
    {
        public int Id { get; set; }
    }
}
