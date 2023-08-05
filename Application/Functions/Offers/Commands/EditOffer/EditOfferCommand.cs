using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Commands.EditOffer
{
    public class EditOfferCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public decimal PricePreDay { get; set; }
        public decimal PricePerHour { get; set; }
    }
}
