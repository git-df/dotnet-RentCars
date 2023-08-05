using UI.Services;

namespace UI.Interfaces
{
    public interface ICarModelService
    {
        Task<GetModelsListQueryVMListBaseResponse> GetModelsList(GetModelsListQuery requestModel);
        Task<BaseResponse> AddModel(AddModelCommand requestModel);
        Task<BaseResponse> EditModel(EditModelCommand requestModel);
        Task<BaseResponse> RemoveModel(RemoveModelCommand requestModel);
    }
}
