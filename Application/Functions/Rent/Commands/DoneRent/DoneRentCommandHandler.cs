using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Commands.DoneRent
{
    public class DoneRentCommandHandler : IRequestHandler<DoneRentCommand, BaseResponse>
    {
        IMapper _mapper;
        IRentRepository _rentRepository;

        public DoneRentCommandHandler(IMapper mapper, IRentRepository rentRepository)
        {
            _mapper = mapper;
            _rentRepository = rentRepository;
        }

        public async Task<BaseResponse> Handle(DoneRentCommand request, CancellationToken cancellationToken)
        {
            if (!(request.RentId >= 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _rentRepository.GetWithPayment(request.RentId);

            if (data == null)
                return new BaseResponse("Brak zamówienia", false);

            if (data.Status != "Zaakceptowane")
                return new BaseResponse("Można wykonać tylko w statusie zaakceptowany", false);

            data.Status = "Zrealizowane";
            await _rentRepository.Update(data);

            return new BaseResponse("Wykonano");
        }
    }
}
