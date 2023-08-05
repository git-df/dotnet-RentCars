using AutoMapper;
using UI.Interfaces;
using UI.Interfaces.Security;

namespace UI.Services
{
    public class CarAttributeService : ICarAttributeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly IAddBearerTokenService _addBearerTokenService;

        public CarAttributeService(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _addBearerTokenService = addBearerTokenService;
            _mapper = mapper;
            _client = client;
        }

        public async Task<BaseResponse> AddAttribute(AddCarAtributeCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.AddCarAtributeAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> EditAttribute(EditCarAtributeCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.EditCarAtributeAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetCarAtributesByCarQueryVMListBaseResponse> GetAtributesByCar(GetCarAtributesByCarQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetCarAtributesByCarAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetCarAtributesByCarQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> RemoveAttribute(RemoveCarAtributeCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.RemoveCarAtributeAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }
    }
}
