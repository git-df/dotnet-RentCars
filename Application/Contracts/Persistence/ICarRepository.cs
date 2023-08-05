using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface ICarRepository : IAsyncRepository<Car>
    {
        Task<List<Car>> GetCarsWithModels(int page, int pageSize, string search);
        Task<int> GetSearchCarsCount(string search);
        Task<List<Car>> GetCarsByModelId(int modelId, int page, int pageSize, string search);
        Task<int> GetCarsByModelIdCount(int modelId, string search);
        Task<Car> GetCarById(int id);
        Task<Car> GetCar(int id);
        Task<List<Car>> GetRentOptions(int barnchId, DateTime from, DateTime to, string search);
        Task<List<Car>> GetCarsActive();
        Task<Car> GetRentOptionDetails(int carId, DateTime from, DateTime to);
    }
}
