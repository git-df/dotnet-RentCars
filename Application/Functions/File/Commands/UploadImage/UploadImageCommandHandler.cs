using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.File.Commands.UploadImage
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, BaseResponse>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadImageCommandHandler(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<BaseResponse> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var image = Convert.FromBase64String(request.Base64Data);

            await System.IO.File.WriteAllBytesAsync(_webHostEnvironment.ContentRootPath + "/wwwroot/img/" + request.FileName, image);

            var a = _webHostEnvironment.ContentRootPath;

            return new BaseResponse("Zapisano zdjęcie");
        }
    }
}
