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
    public class OfferRepository : AsyncRepository<Offer>, IOfferRepository
    {
        public OfferRepository(RentCarsDbContext rentCarsDbContext) : base(rentCarsDbContext)
        {
        }

        public async Task<Offer?> GetOfferByCarAndBranch(int carId, int brancId)
        {
            return await _context.Offers
                .Include(e => e.Car)
                .Include(e => e.Branch)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.CarId == carId && e.BranchId == brancId);
        }

        public async Task<List<Offer>> GetOffers(int page, int pageSize, string search)
        {
            return await _context.Offers
                .Include(e => e.Car).ThenInclude(ee => ee.CarsModel)
                .Include(e => e.Branch)
                .Where(e => e.Car.IsDeleted == false)
                .AsNoTracking()
                .Where(e => search.IsNullOrEmpty() || (e.Car.CarsModel.BrandName + " " + e.Car.CarsModel.ModelName + " " + e.Car.VIN + " " + e.Car.PlaceNumber).ToLower().Contains(search.ToLower()))
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetOffersCount(string search)
        {
            return await _context.Offers
                .Include(e => e.Car)
                .Where(e => e.Car.IsDeleted == false)
                .Where(e => search.IsNullOrEmpty() || (e.Car.CarsModel.BrandName + " " + e.Car.CarsModel.ModelName + " " + e.Car.VIN + " " + e.Car.PlaceNumber).ToLower().Contains(search.ToLower()))
                .CountAsync();
        }
    }
}
