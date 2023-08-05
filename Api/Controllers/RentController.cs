using Application.Functions.Rent.Commands.AddRent;
using Application.Functions.Rent.Commands.ConfirmRent;
using Application.Functions.Rent.Commands.DeleteRent;
using Application.Functions.Rent.Commands.DoneRent;
using Application.Functions.Rent.Commands.NoConfirmRent;
using Application.Functions.Rent.Queries.GetAllRents;
using Application.Functions.Rent.Queries.GetBranchesWithOfferts;
using Application.Functions.Rent.Queries.GetMyRents;
using Application.Functions.Rent.Queries.GetRentOptions;
using Application.Functions.Rent.Queries.GetRentOptionsDetails;
using Application.Responses;
using Azure.Core;
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
    public class RentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetRentOptionsQueryVM>>> GetRentOptions([FromBody] GetRentOptionsQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse<GetRentOptionsDetailsQueryVM>> GetRentOptionsDetails([FromBody] GetRentOptionsDetailsQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<BaseResponse<List<GetBranchesWithOffertsQueryVM>>> GetBranchesWithOfferts()
        {
            return await _mediator.Send(new GetBranchesWithOffertsQuery());
        }

        [HttpPut]
        public async Task<BaseResponse> AddRent([FromBody] AddRentCommand request)
        {
            string stringClaimId = (HttpContext.User.Identity as ClaimsIdentity)?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";
            request.UserAppId = Int32.Parse(stringClaimId);

            return await _mediator.Send<BaseResponse>(request);
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetMyRentsQueryVM>>> GetMyRents([FromBody] GetMyRentsQuery request)
        {
            string stringClaimId = (HttpContext.User.Identity as ClaimsIdentity)?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";
            request.Id = Int32.Parse(stringClaimId);

            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetAllRentsQueryVM>>> GeAllRents([FromBody] GetAllRentsQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<BaseResponse> DeleteRent([FromBody] DeleteRentCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse> ConfirmRent([FromBody] ConfirmRentCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse> NoConfirmRent([FromBody] NoConfirmRentCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse> DoneRent([FromBody] DoneRentCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
