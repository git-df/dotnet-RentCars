using Application.Contracts.Persistence;
using Application.Functions.Rent.Queries.GetMyRents;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Commands.DeleteRent
{
    public class DeleteRentCommandHandler : IRequestHandler<DeleteRentCommand, BaseResponse>
    {
        IMapper _mapper;
        IRentRepository _rentRepository;
        IPaymentRepository _paymentRepository;

        public DeleteRentCommandHandler(IMapper mapper, IRentRepository rentRepository, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _rentRepository = rentRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<BaseResponse> Handle(DeleteRentCommand request, CancellationToken cancellationToken)
        {
            if (!(request.RentId >= 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _rentRepository.GetById(request.RentId);

            if (data == null)
                return new BaseResponse("Brak zamówienia", false);

            if (data.Status != "Nowe")
                return new BaseResponse("Usunąć można tylko w statusie nowy", false);

            await _paymentRepository.DeletePaymentByRentId(request.RentId);
            await _rentRepository.Delete(data);

            return new BaseResponse("Usunięto zamówienie");
        }
    }
}
