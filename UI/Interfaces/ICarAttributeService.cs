using UI.Services;

namespace UI.Interfaces
{
    public interface ICarAttributeService
    {
        Task<GetCarAtributesByCarQueryVMListBaseResponse> GetAtributesByCar(GetCarAtributesByCarQuery requestModel);
        Task<BaseResponse> AddAttribute(AddCarAtributeCommand requestModel);
        Task<BaseResponse> RemoveAttribute(RemoveCarAtributeCommand requestModel);
        Task<BaseResponse> EditAttribute(EditCarAtributeCommand requestModel);
    }
}
