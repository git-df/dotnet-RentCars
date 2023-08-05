using Blazored.LocalStorage;
using System.Net.Http.Headers;
using UI.Interfaces.Security;

namespace UI.Services.Security
{
    public class AddBearerTokenService : IAddBearerTokenService
    {
        private readonly ILocalStorageService _localStorage;

        public AddBearerTokenService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task AddBearerToken(IClient client)
        {
            if (await _localStorage.ContainKeyAsync("token"))
                client.HttpClient.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
        }
    }
}
