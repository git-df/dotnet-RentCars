using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Queries.GetContacts
{
    public class GetContactsQuery : IRequest<BaseResponse<List<GetContactsQueryVM>>>
    {
    }
}
