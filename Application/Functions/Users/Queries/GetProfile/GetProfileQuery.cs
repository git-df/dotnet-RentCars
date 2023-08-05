using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Users.Queries.GetProfile
{
    public class GetProfileQuery : IRequest<BaseResponse<GetProfileQueryVM>>
    {
        public int Id { get; set; }
    }
}
