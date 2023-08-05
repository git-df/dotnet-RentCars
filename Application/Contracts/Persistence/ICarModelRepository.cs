using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface ICarModelRepository : IAsyncRepository<CarsModel>
    {
        Task<List<CarsModel>> GetModelsWithCarCounts(int page, int pageSize, string search);
        Task<int> GetSearchModelsCount(string search);
        Task<CarsModel> GetByIdWithCars(int id);
        Task DeleteModel(CarsModel model);
    }
}
