using Application.Contracts.Persistence;
using Application.Functions.Payments.Queries.GetMyPayments;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Payments.Commands.Pay
{
    public class PayCommandHandler : IRequestHandler<PayCommand, BaseResponse>
    {
        private readonly IPaymentRepository _paymentRepository;

        public PayCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<BaseResponse> Handle(PayCommand request, CancellationToken cancellationToken)
        {
            if (!(request.PaymentId >= 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _paymentRepository.GetById(request.PaymentId);

            if (data == null)
                return new BaseResponse("Brak płatności", false);

            data.Status = "Wykonana";

            await _paymentRepository.Update(data);

            return new BaseResponse("Zapłacono");
        }
    }
}
