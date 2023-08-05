using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace UI.Services.Security
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var jwtToken = await _localStorage.GetItemAsync<string>("token");

            if (string.IsNullOrWhiteSpace(jwtToken))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(GetClaimsFromToken(jwtToken), "jwt")));
        }

        public void SetUserAuthenticated(string jwtToken)
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(GetClaimsFromToken(jwtToken), "apiauth"));
            var state = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(state);
        }

        public void SetUserLoggedOut()
        {
            var userNoAuth = new ClaimsPrincipal(new ClaimsIdentity());
            var state = Task.FromResult(new AuthenticationState(userNoAuth));
            NotifyAuthenticationStateChanged(state);
        }

        public IEnumerable<Claim> GetClaimsFromToken(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);
            return token.Claims;
        }
    }
}