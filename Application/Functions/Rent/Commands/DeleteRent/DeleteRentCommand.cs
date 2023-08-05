using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Commands.DeleteRent
{
    public class DeleteRentCommand : IRequest<BaseResponse>
    {
        public int RentId { get; set; }
    }
}
