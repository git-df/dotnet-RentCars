using AutoMapper;
using UI.Interfaces;
using UI.Interfaces.Security;

namespace UI.Services
{
    public class OfferService : IOfferService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly IAddBearerTokenService _addBearerTokenService;

        public OfferService(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _addBearerTokenService = addBearerTokenService;
            _mapper = mapper;
            _client = client;
        }

        public async Task<BaseResponse> AddOffer(AddOfferCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.AddOfferAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> DeleteOffer(DeleteOfferCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.DeleteOfferAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> EditOffer(EditOfferCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.EditOfferAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetBranchesToOfferQueryVMListBaseResponse> GetBranchesToOffer()
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetBranchesToOfferAsync();
            }
            catch (Exception ex)
            {
                return new GetBranchesToOfferQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetCarsToOfferQueryVMListBaseResponse> GetCarsToOffer()
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetCarsToOfferAsync();
            }
            catch (Exception ex)
            {
                return new GetCarsToOfferQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetOffersQueryVMListBaseResponse> GetOffers(GetOffersQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetOffersAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetOffersQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }
    }
}
