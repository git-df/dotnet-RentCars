using UI.Services;

namespace UI.Interfaces
{
    public interface IFileService
    {
        Task<BaseResponse> UploadImage(UploadImageCommand requestModel);
    }
}
