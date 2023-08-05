using Application.Functions.File.Commands.UploadImage;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api.Controllers
{
    [Authorize(Roles = "Employee, Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<BaseResponse> UploadImage([FromBody] UploadImageCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
