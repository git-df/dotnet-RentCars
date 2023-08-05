using UI.Services;

namespace UI.Interfaces
{
    public interface ICarService
    {
        Task<GetCarsByModelQueryVMListBaseResponse> GetCarsByModel(GetCarsByModelQuery requestModel);
        Task<GetCarDetailsQueryVMBaseResponse> GetCarDetails(GetCarDetailsQuery requestModel);
        Task<Int32BaseResponse> AddCar(AddCarCommand requestModel);
        Task<BaseResponse> EditCar(EditCarCommand requestModel);
        Task<BaseResponse> RemoveCar(RemoveCarCommand requestModel);
        Task<BaseResponse> ChangeImage(ChangeImageCommand requestModel);
    }
}
