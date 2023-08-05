using Application.Contracts.Persistence;
using Application.Functions.Offers.Commands.EditOffer;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Commands.DeleteOffer
{
    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;

        public DeleteOfferCommandHandler(IMapper mapper, IOfferRepository offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<BaseResponse> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _offerRepository.GetById(request.Id);

            if (data == null)
                return new BaseResponse("Nie ma oferty z takim id", false);

            await _offerRepository.Delete(data);

            return new BaseResponse("Usunięto ofertę");
        }
    }
}
