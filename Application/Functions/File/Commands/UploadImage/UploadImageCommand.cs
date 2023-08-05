using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.File.Commands.UploadImage
{
    public class UploadImageCommand : IRequest<BaseResponse>
    {
        public string Base64Data { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}
