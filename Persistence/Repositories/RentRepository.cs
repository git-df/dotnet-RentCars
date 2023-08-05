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
    public class RentRepository : AsyncRepository<Rent>, IRentRepository
    {
        public RentRepository(RentCarsDbContext rentCarsDbContext) : base(rentCarsDbContext)
        {
        }

        public async Task<Rent> AddRent(Rent rent)
        {
            _context.Rents.Add(rent);

            await _context.SaveChangesAsync();

            return rent;
        }

        public async Task<List<Rent>> GetAllRents(int page, int pageSize, string search)
        {
            return await _context.Rents
                .Include(e => e.Car).ThenInclude(ee => ee.CarsModel)
                .Include(e => e.RentPayment)
                .Include(e => e.UserApp)
                .Where(e => search.IsNullOrEmpty() || (e.Car.CarsModel.BrandName + " " + e.Car.CarsModel.ModelName + " " + e.Car.VIN + " " + e.Car.PlaceNumber).ToLower().Contains(search.ToLower()))
                .OrderByDescending(e => e.Created)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetAllRentsCount(string search)
        {
            return await _context.Rents
                .Include(e => e.Car).ThenInclude(ee => ee.CarsModel)
                .Include(e => e.RentPayment)
                .Include(e => e.UserApp)
                .Where(e => search.IsNullOrEmpty() || (e.Car.CarsModel.BrandName + " " + e.Car.CarsModel.ModelName + " " + e.Car.VIN + " " + e.Car.PlaceNumber).ToLower().Contains(search.ToLower()))
                .CountAsync();
        }

        public async Task<List<Rent>> GetRentsByUserId(int userId, int page, int pageSize, string search)
        {
            return await _context.Rents
                .Include(e => e.Car).ThenInclude(ee => ee.CarsModel)
                .Include(e => e.RentPayment)
                .Where(e => e.UserAppId == userId)
                .Where(e => search.IsNullOrEmpty() || (e.Car.CarsModel.BrandName + " " + e.Car.CarsModel.ModelName + " " + e.Car.VIN + " " + e.Car.PlaceNumber).ToLower().Contains(search.ToLower()))
                .OrderByDescending(e => e.Created)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetRentsByUserIdCount(int userId, string search)
        {
            return await _context.Rents
                .Include(e => e.Car).ThenInclude(ee => ee.CarsModel)
                .Include(e => e.RentPayment)
                .Where(e => e.UserAppId == userId)
                .Where(e => search.IsNullOrEmpty() || (e.Car.CarsModel.BrandName + " " + e.Car.CarsModel.ModelName + " " + e.Car.VIN + " " + e.Car.PlaceNumber).ToLower().Contains(search.ToLower()))
                .CountAsync();
        }

        public async Task<Rent?> GetWithPayment(int rentId)
        {
            return await _context.Rents
                .Include(e => e.RentPayment)
                .FirstOrDefaultAsync(e => e.Id == rentId);
        }
    }
}
