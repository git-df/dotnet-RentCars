using Application.Functions.Payments.Commands.Pay;
using Application.Functions.Payments.Queries.GetAllPayments;
using Application.Functions.Payments.Queries.GetMyPayments;
using Application.Functions.Rent.Commands.NoConfirmRent;
using Application.Functions.Rent.Queries.GetAllRents;
using Application.Functions.Rent.Queries.GetMyRents;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetMyPaymentsQueryVM>>> GetMyPayments([FromBody] GetMyPaymentsQuery request)
        {
            string stringClaimId = (HttpContext.User.Identity as ClaimsIdentity)?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";
            request.Id = Int32.Parse(stringClaimId);

            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetAllPaymentsQueryVM>>> GetAllPayments([FromBody] GetAllPaymentsQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse> Pay([FromBody] PayCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
