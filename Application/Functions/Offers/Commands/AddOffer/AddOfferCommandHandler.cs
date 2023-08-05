using Application.Contracts.Persistence;
using Application.Functions.Branches.Commands.AddBranch;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Commands.AddOffer
{
    public class AddOfferCommandHandler : IRequestHandler<AddOfferCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        private readonly ICarRepository _carRepository;
        private readonly IBranchRepository _branchRepository;

        public AddOfferCommandHandler(IMapper mapper, IOfferRepository offerRepository, ICarRepository carRepository, IBranchRepository branchRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
            _carRepository = carRepository;
            _branchRepository = branchRepository;
        }

        public async Task<BaseResponse> Handle(AddOfferCommand request, CancellationToken cancellationToken)
        {
            if (!(request.CarId > 0) || !(request.BranchId > 0))
                return new BaseResponse("Wybierz samochód oraz oddział", false);

            var data = await _offerRepository.GetOfferByCarAndBranch(request.CarId, request.BranchId);

            if (data != null)
                return new BaseResponse("Jest już oferta dla tego samochodu w tym oddziale", false);

            var validator = new AddOfferCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            var car = await _carRepository.GetById(request.CarId);

            if (car == null)
                return new BaseResponse("Nie ma samochoduz takim id", false);

            if (car.IsDeleted)
                return new BaseResponse("Samochód został usunięty", false);

            var branch = await _branchRepository.GetById(request.BranchId);

            if (branch == null)
                return new BaseResponse("Nie ma oddziału z takim id", false);

            var newOffer = await _offerRepository.Add(
                _mapper.Map<Offer>(request));

            if (!(newOffer.Id > 0))
                return new BaseResponse("Nie udało się dodać", false);

            return new BaseResponse("Oferta została dodana");
        }
    }
}
