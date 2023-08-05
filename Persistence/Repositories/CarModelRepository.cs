using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CarModelRepository : AsyncRepository<CarsModel>, ICarModelRepository
    {
        public CarModelRepository(RentCarsDbContext rentCarsDbContext) : base(rentCarsDbContext)
        {
        }

        public async Task DeleteModel(CarsModel model)
        {
            model.IsDeleted = true;

            await _context.SaveChangesAsync();
        }

        public async Task<CarsModel?> GetByIdWithCars(int id)
        {
            return await _context.CarsModels
                .Include(e => e.Cars)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<CarsModel>> GetModelsWithCarCounts(int page, int pageSize, string search)
        {
            return await _context.CarsModels
                .Where(e => e.IsDeleted == false)
                .Where(e => search.IsNullOrEmpty() || (e.BrandName+e.ModelName).ToLower().Contains(search.ToLower()))
                .OrderBy(e => (e.BrandName + e.ModelName))
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Include(e => e.Cars)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetSearchModelsCount(string search)
        {
            return await _context.CarsModels
                .Where(e => e.IsDeleted == false)
                .Where(e => search.IsNullOrEmpty() || (e.BrandName + e.ModelName).ToLower().Contains(search.ToLower()))
                .CountAsync();
        }
    }
}
