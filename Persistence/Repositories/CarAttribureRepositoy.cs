using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CarAttribureRepositoy : AsyncRepository<CarAttribute>, ICarAttribureRepositoy
    {
        public CarAttribureRepositoy(RentCarsDbContext rentCarsDbContext) : base(rentCarsDbContext)
        {
        }

        public Task<List<CarAttribute>> GetCarAttributesByCarId(int id)
        {
            return _context.CarAttributes
                .Include(e => e.Car)
                .Where(e => e.CarId == id)
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
    }
}
