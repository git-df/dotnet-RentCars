using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Commands.ConfirmRent
{
    public class ConfirmRentCommandHandler : IRequestHandler<ConfirmRentCommand, BaseResponse>
    {
        IMapper _mapper;
        IRentRepository _rentRepository;
        IPaymentRepository _paymentRepository;

        public ConfirmRentCommandHandler(IMapper mapper, IRentRepository rentRepository, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _rentRepository = rentRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<BaseResponse> Handle(ConfirmRentCommand request, CancellationToken cancellationToken)
        {
            if (!(request.RentId >= 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _rentRepository.GetWithPayment(request.RentId);

            if (data == null)
                return new BaseResponse("Brak zamówienia", false);

            if (data.Status != "Nowe")
                return new BaseResponse("Można potwierdzić tylko w statusie nowy", false);

            data.Status = "Zaakceptowane";
            await _rentRepository.Update(data);

            if (data.RentPayment != null)
            {
                data.RentPayment.Status = "Oczekująca";
                await _paymentRepository.Update(data.RentPayment);
            }

            return new BaseResponse("Zatwierdzono");
        }
    }
}
