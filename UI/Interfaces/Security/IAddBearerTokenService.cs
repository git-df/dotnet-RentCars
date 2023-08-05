using UI.Services;

namespace UI.Interfaces.Security
{
    public interface IAddBearerTokenService
    {
        Task AddBearerToken(IClient client);
    }
}
