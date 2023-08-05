using AutoMapper;
using UI.Interfaces;
using UI.Interfaces.Security;

namespace UI.Services
{
    public class HomeService : IHomeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly IAddBearerTokenService _addBearerTokenService;

        public HomeService(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _addBearerTokenService = addBearerTokenService;
            _mapper = mapper;
            _client = client;
        }

        public async Task<GetCarQueryVMBaseResponse> GetCar(GetCarQuery requestModel)
        {
            try
            {
                return await _client.GetCarAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetCarQueryVMBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetCarsQueryVMListBaseResponse> GetCars(GetCarsQuery requestModel)
        {
            try
            {
                return await _client.GetCarsAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetCarsQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetContactsQueryVMListBaseResponse> GetContacts()
        {
            try
            {
                return await _client.GetContactsAsync();
            }
            catch (Exception ex)
            {
                return new GetContactsQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }
    }
}
