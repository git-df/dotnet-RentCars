using UI.Services;

namespace UI.Interfaces
{
    public interface IHomeService
    {
        Task<GetContactsQueryVMListBaseResponse> GetContacts();
        Task<GetCarsQueryVMListBaseResponse> GetCars(GetCarsQuery requestModel);
        Task<GetCarQueryVMBaseResponse> GetCar(GetCarQuery requestModel);
    }
}
