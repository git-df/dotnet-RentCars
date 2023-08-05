using UI.Interfaces;
using UI.Interfaces.Security;

namespace UI.Services
{
    public class FileService : IFileService
    {
        private readonly IClient _client;
        private readonly IAddBearerTokenService _addBearerTokenService;

        public FileService(IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _addBearerTokenService = addBearerTokenService;
            _client = client;
        }

        public async Task<BaseResponse> UploadImage(UploadImageCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.UploadImageAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }
    }
}
