using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Commands.AddRent
{
    public class AddRentCommandHandler : IRequestHandler<AddRentCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        private readonly IRentRepository _rentRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUserAppRepository _userAppRepository;
        private readonly ICarRepository _carRepository;

        public AddRentCommandHandler(IMapper mapper, IOfferRepository offerRepository, IRentRepository rentRepository, IPaymentRepository paymentRepository, ICarRepository carRepository, IUserAppRepository userAppRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
            _rentRepository = rentRepository;
            _paymentRepository = paymentRepository;
            _carRepository = carRepository;
            _userAppRepository = userAppRepository;
        }

        public async Task<BaseResponse> Handle(AddRentCommand request, CancellationToken cancellationToken)
        {
            if (!(request.CarId >= 0) || !(request.UserAppId >= 0) || !(request.OfferId >= 0))
                return new BaseResponse("Błędne Id", false);

            var offer = await _offerRepository.GetById(request.OfferId);

            if (offer == null)
                return new BaseResponse("Brak oferty", false);

            var user = await _userAppRepository.GetById(request.UserAppId);

            if (user == null)
                return new BaseResponse("Brak użytkownika", false);

            var car = await _carRepository.GetById(request.CarId);

            if (car == null)
                return new BaseResponse("Brak samochodu", false);

            var rent = await _rentRepository.AddRent(new Domain.Entities.Rent()
            {
                Status = "Nowe",
                CarId = request.CarId,
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                UserAppId = request.UserAppId
            });

            if (rent == null)
                return new BaseResponse("Nie udało się zamówić", false);

            var payment = await _paymentRepository.Add(new RentPayment()
            {
                Status = "Nowa",
                RentId = rent.Id,
                Price = RentPriceCalcHandler.CalcPrice(request.DateFrom, request.DateTo, offer.PricePerHour, offer.PricePreDay)
            });

            if (payment == null)
                return new BaseResponse("Nie udało się dodać płatnści", false);

            return new BaseResponse("Dodano zamówienie");
        }
    }
}
