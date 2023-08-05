using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Commands.EditCar
{
    public class EditCarCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string PlaceNumber { get; set; }
        public string VIN { get; set; }
        public string Fuel { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
    }
}
