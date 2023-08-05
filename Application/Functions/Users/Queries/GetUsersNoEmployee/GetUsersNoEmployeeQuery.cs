using Application.Functions.Common;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Users.Queries.GetUsersNoEmployee
{
    public class GetUsersNoEmployeeQuery : ListRequestOptions, IRequest<BaseResponse<List<GetUsersNoEmployeeQueryVM>>>
    {
    }
}
