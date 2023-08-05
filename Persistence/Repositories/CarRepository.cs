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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Persistence.Repositories
{
    public class CarRepository : AsyncRepository<Car>, ICarRepository
    {
        public CarRepository(RentCarsDbContext rentCarsDbContext) : base(rentCarsDbContext)
        {
        }

        public async Task<Car?> GetCar(int id)
        {
            return await _context.Cars
                .Include(e => e.CarsModel)
                .Include(e => e.CarAttributes)
                .Include(e => e.Offers).ThenInclude(ee => ee.Branch)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Car?> GetCarById(int id)
        {
            return await _context.Cars
                .Include(e => e.CarsModel)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Car>> GetCarsActive()
        {
            return await _context.Cars
                .Where(e => e.IsDeleted == false)
                .Include(e => e.CarsModel)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Car>> GetCarsByModelId(int modelId, int page, int pageSize, string search)
        {
            return await _context.Cars
                .Include(e => e.CarsModel)
                .Include(e => e.Rents)
                .Include(e => e.Offers)
                .Where(e => e.IsDeleted == false)
                .Where(e => e.CarsModelId == modelId)
                .Where(e => search.IsNullOrEmpty() || (e.CarsModel.BrandName + " " + e.CarsModel.ModelName + " " + e.VIN + " " + e.PlaceNumber).ToLower().Contains(search.ToLower()))
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetCarsByModelIdCount(int modelId, string search)
        {
            return await _context.Cars
                .Include(e => e.CarsModel)
                .Where(e => e.IsDeleted == false)
                .Where(e => e.CarsModelId == modelId)
                .Where(e => search.IsNullOrEmpty() || (e.CarsModel.BrandName + " " + e.CarsModel.ModelName + " " + e.VIN + " " + e.PlaceNumber).ToLower().Contains(search.ToLower()))
                .CountAsync();
        }

        public async Task<List<Car>> GetCarsWithModels(int page, int pageSize, string search)
        {
            return await _context.Cars
                .Include(e => e.CarsModel)
                .Where(e => e.IsDeleted == false)
                .Where(e => search.IsNullOrEmpty() || (e.CarsModel.BrandName + " " + e.CarsModel.ModelName).ToLower().Contains(search.ToLower()))
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Car?> GetRentOptionDetails(int carId, DateTime from, DateTime to)
        {
            return await _context.Cars
                .Where(e => e.IsDeleted == false)
                .Include(e => e.CarsModel)
                .Include(e => e.Offers).ThenInclude(ee => ee.Branch)
                .Include(e => e.Rents)
                .Include(e => e.CarAttributes)
                .Where(e => !(e.Rents.Where(ee => ee.DateFrom < to && ee.DateTo > from).Any()))
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == carId);
        }

        public async Task<List<Car>> GetRentOptions(int barnchId, DateTime from, DateTime to, string search)
        {
            return await _context.Cars
                .Where(e => e.IsDeleted == false)
                .Include(e => e.CarsModel)
                .Include(e => e.Offers)
                .Include(e => e.Rents)
                .Where(e => e.Offers.Any())
                .Where(e => barnchId == 0 || e.Offers.Where(ee => ee.BranchId == barnchId).Any())
                .Where(e => !(e.Rents.Where(ee => ee.DateFrom < to && ee.DateTo > from).Any()))
                .Where(e => search.IsNullOrEmpty() || (e.CarsModel.BrandName + " " + e.CarsModel.ModelName).ToLower().Contains(search.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetSearchCarsCount(string search)
        {
            return await _context.Cars
                .Where(e => e.IsDeleted == false)
                .Where(e => search.IsNullOrEmpty() || (e.CarsModel.BrandName + " " + e.CarsModel.ModelName).ToLower().Contains(search.ToLower()))
                .CountAsync();
        }
    }
}
