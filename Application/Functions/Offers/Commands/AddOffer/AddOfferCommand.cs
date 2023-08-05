using Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Commands.AddOffer
{
    public class AddOfferCommand : IRequest<BaseResponse>
    {
        public decimal PricePreDay { get; set; }
        public decimal PricePerHour { get; set; }
        public int CarId { get; set; }
        public int BranchId { get; set; }
    }
}
