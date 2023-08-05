using Application.Contracts.Persistence;
using Application.Functions.Offers.Commands.AddOffer;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Commands.EditOffer
{
    public class EditOfferCommandHandler : IRequestHandler<EditOfferCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;

        public EditOfferCommandHandler(IMapper mapper, IOfferRepository offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<BaseResponse> Handle(EditOfferCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            if (!(request.PricePerHour > 0) || !(request.PricePreDay > 0))
                return new BaseResponse("Błędne kwoty", false);

            var validator = new EditOfferCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            var data = await _offerRepository.GetById(request.Id);

            if (data == null)
                return new BaseResponse("Nie ma oferty z takim id", false);

            data.PricePerHour = request.PricePerHour;
            data.PricePreDay = request.PricePreDay;

            await _offerRepository.Update(data);

            return new BaseResponse("Edytowano ofertę");
        }
    }
}
