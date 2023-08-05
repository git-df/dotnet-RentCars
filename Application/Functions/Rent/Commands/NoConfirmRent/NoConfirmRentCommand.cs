using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Commands.NoConfirmRent
{
    public class NoConfirmRentCommand : IRequest<BaseResponse>
    {
        public int RentId { get; set; }
    }
}
