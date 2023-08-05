using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Commands.NoConfirmRent
{
    public class NoConfirmRentCommandHandler : IRequestHandler<NoConfirmRentCommand, BaseResponse>
    {
        IMapper _mapper;
        IRentRepository _rentRepository;
        IPaymentRepository _paymentRepository;

        public NoConfirmRentCommandHandler(IMapper mapper, IRentRepository rentRepository, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _rentRepository = rentRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<BaseResponse> Handle(NoConfirmRentCommand request, CancellationToken cancellationToken)
        {
            if (!(request.RentId >= 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _rentRepository.GetWithPayment(request.RentId);

            if (data == null)
                return new BaseResponse("Brak zamówienia", false);

            if (data.Status != "Nowe")
                return new BaseResponse("Można odrzucić tylko w statusie nowy", false);

            data.Status = "Odrzucone";
            await _rentRepository.Update(data);

            if (data.RentPayment != null)
            {
                data.RentPayment.Status = "Anulowana";
                await _paymentRepository.Update(data.RentPayment);
            }

            return new BaseResponse("Odrzucono");
        }
    }
}
