using Application.Functions.Cars.Queries.GetCars;
using Application.Functions.Offers.Commands.AddOffer;
using Application.Functions.Offers.Commands.DeleteOffer;
using Application.Functions.Offers.Commands.EditOffer;
using Application.Functions.Offers.Queries.GetBranchesToOffer;
using Application.Functions.Offers.Queries.GetCarsToOffer;
using Application.Functions.Offers.Queries.GetOffers;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetOffersQueryVM>>> GetOffers([FromBody] GetOffersQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<BaseResponse> AddOffer([FromBody] AddOfferCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPatch]
        public async Task<BaseResponse> EditOffer([FromBody] EditOfferCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<BaseResponse> DeleteOffer([FromBody] DeleteOfferCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<BaseResponse<List<GetBranchesToOfferQueryVM>>> GetBranchesToOffer()
        {
            return await _mediator.Send(new GetBranchesToOfferQuery());
        }

        [HttpGet]
        public async Task<BaseResponse<List<GetCarsToOfferQueryVM>>> GetCarsToOffer()
        {
            return await _mediator.Send(new GetCarsToOfferQuery());
        }
    }
}
