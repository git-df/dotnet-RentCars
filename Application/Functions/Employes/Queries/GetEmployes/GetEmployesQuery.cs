using Application.Functions.Common;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Queries.GetEmployes
{
    public class GetEmployesQuery : ListRequestOptions, IRequest<BaseResponse<List<GetEmployesQueryVM>>>
    {
    }
}
