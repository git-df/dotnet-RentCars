using Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Commands.AddRent
{
    public class AddRentCommand : IRequest<BaseResponse>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public int CarId { get; set; }
        public int UserAppId { get; set; }
        public int OfferId { get; set; }
    }
}
