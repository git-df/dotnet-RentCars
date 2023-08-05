using Application.Contracts.Persistence;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Commands.ChangeImage
{
    public class ChangeImageCommandHandler : IRequestHandler<ChangeImageCommand, BaseResponse>
    {
        private readonly ICarRepository _carRepository;

        public ChangeImageCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<BaseResponse> Handle(ChangeImageCommand request, CancellationToken cancellationToken)
        {
            if (!(request.CarId > 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _carRepository.GetById(request.CarId);

            if (data == null)
                return new BaseResponse("Brak samochodu z takim Id", false);

            data.Image = request.Image;

            await _carRepository.Update(data);

            return new BaseResponse("Zmieniono zdjęcie");
        }
    }
}
