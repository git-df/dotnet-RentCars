﻿using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Commands.ChangeImage
{
    public class ChangeImageCommand : IRequest<BaseResponse>
    {
        public int CarId { get; set; }
        public string Image { get; set; }
    }
}
