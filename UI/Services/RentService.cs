using AutoMapper;
using UI.Interfaces;
using UI.Interfaces.Security;

namespace UI.Services
{
    public class RentService : IRentService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly IAddBearerTokenService _addBearerTokenService;

        public RentService(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _addBearerTokenService = addBearerTokenService;
            _mapper = mapper;
            _client = client;
        }

        public async Task<BaseResponse> AddRent(AddRentCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.AddRentAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> ConfirmRent(ConfirmRentCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.ConfirmRentAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> DeleteRent(DeleteRentCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.DeleteRentAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }
        public async Task<BaseResponse> DoneRent(DoneRentCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.DoneRentAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetAllRentsQueryVMListBaseResponse> GetAllRents(GetAllRentsQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GeAllRentsAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetAllRentsQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetBranchesWithOffertsQueryVMListBaseResponse> GetBranchesWithOfferts()
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetBranchesWithOffertsAsync();
            }
            catch (Exception ex)
            {
                return new GetBranchesWithOffertsQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetMyRentsQueryVMListBaseResponse> GetMyRents(GetMyRentsQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetMyRentsAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetMyRentsQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetRentOptionsQueryVMListBaseResponse> GetRentOptions(GetRentOptionsQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetRentOptionsAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetRentOptionsQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetRentOptionsDetailsQueryVMBaseResponse> GetRentOptionsDetails(GetRentOptionsDetailsQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetRentOptionsDetailsAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetRentOptionsDetailsQueryVMBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> NoConfirmRent(NoConfirmRentCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.NoConfirmRentAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }
    }
}
