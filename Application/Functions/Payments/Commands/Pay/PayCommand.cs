using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Payments.Commands.Pay
{
    public class PayCommand : IRequest<BaseResponse>
    {
        public int PaymentId { get; set; }
    }
}
