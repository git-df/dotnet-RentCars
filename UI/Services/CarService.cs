using AutoMapper;
using UI.Interfaces;
using UI.Interfaces.Security;

namespace UI.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly IAddBearerTokenService _addBearerTokenService;

        public CarService(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _addBearerTokenService = addBearerTokenService;
            _mapper = mapper;
            _client = client;
        }

        public async Task<Int32BaseResponse> AddCar(AddCarCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.AddCarAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new Int32BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> ChangeImage(ChangeImageCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.ChangeImageAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> EditCar(EditCarCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.EditCarAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetCarDetailsQueryVMBaseResponse> GetCarDetails(GetCarDetailsQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetCarDetailsAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetCarDetailsQueryVMBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetCarsByModelQueryVMListBaseResponse> GetCarsByModel(GetCarsByModelQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetCarsByModelAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetCarsByModelQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> RemoveCar(RemoveCarCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.RemoveCarAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }
    }
}
