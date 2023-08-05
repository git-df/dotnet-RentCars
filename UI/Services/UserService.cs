using AutoMapper;
using UI.Interfaces;
using UI.Interfaces.Security;

namespace UI.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly IAddBearerTokenService _addBearerTokenService;

        public UserService(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _addBearerTokenService = addBearerTokenService;
            _mapper = mapper;
            _client = client;
        }

        public async Task<BaseResponse> EditProfile(EditProfileCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.EditProfileAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetMenuVMListBaseResponse> GetMenu()
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetMenuAsync();
            }
            catch (Exception ex)
            {
                return new GetMenuVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetProfileQueryVMBaseResponse> GetProfile()
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetProfileAsync();
            }
            catch (Exception ex)
            {
                return new GetProfileQueryVMBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetUsersNoEmployeeQueryVMListBaseResponse> GetUsersNoEmployee(GetUsersNoEmployeeQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetUsersNoEmployeeAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetUsersNoEmployeeQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }
    }
}
