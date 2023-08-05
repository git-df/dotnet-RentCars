using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using UI.Interfaces.Security;

namespace UI.Services.Security
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorageService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IAddBearerTokenService _addBearerTokenService;

        public AuthService(IMapper mapper, IClient client, ILocalStorageService localStorageService, AuthenticationStateProvider authenticationStateProvider, IAddBearerTokenService addBearerTokenService)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _mapper = mapper;
            _client = client;
            _localStorageService = localStorageService;
            _addBearerTokenService = addBearerTokenService;
        }

        public async Task<GetUserAuthInfoVMBaseResponse> GetUserAuthInfo()
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetUserAuthInfoAsync();
            }
            catch (Exception ex)
            {
                return new GetUserAuthInfoVMBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> PasswordChange(PasswordChangeCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.PasswordChangeAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<StringBaseResponse> SignIn(SignInCommand requestModel)
        {
            try
            {
                var response = await _client.SignInAsync(requestModel);

                if (response.Success && !string.IsNullOrEmpty(response.Data))
                {
                    await _localStorageService.SetItemAsync("token", response.Data);
                    
                    ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(response.Data);
                    
                    _client.HttpClient.DefaultRequestHeaders.Authorization
                        = new AuthenticationHeaderValue("bearer", response.Data);
                }

                return response;
            }
            catch (Exception ex)
            {
                return new StringBaseResponse() { Success = false, Message = ex.Message };
            }
        }

        public async Task SignOut()
        {
            await _localStorageService.RemoveItemAsync("token");
            ((CustomAuthenticationStateProvider) _authenticationStateProvider).SetUserLoggedOut();
        }

        public async Task<BaseResponse> SignUp(SignUpCommand requestModel)
        {
            try
            {
                return await _client.SignUpAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
