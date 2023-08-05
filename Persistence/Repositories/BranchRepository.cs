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
    public class BranchRepository : AsyncRepository<Branch>, IBranchRepository
    {
        public BranchRepository(RentCarsDbContext rentCarsDbContext) : base(rentCarsDbContext)
        {
        }

        public async Task<Branch?> GetBranchByIdWithAddress(int id)
        {
            return await _context.Branches
                .Include(e => e.Address)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Branch?> GetBranchByIdWithAllReferences(int id)
        {
            return await _context.Branches
                .Include(e => e.Address)
                .Include(e => e.Offers)
                .Include(e => e.UserEmployee2Branches)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Branch>> GetBranchesWithAdresses()
        {
            return await _context.Branches
                .Include(e => e.Address)
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

        public async Task<List<Branch>> GetBranchesWithCountOfReferences(int page, int pageSize, string search)
        {
            return await _context.Branches
                .Where(e => search.IsNullOrEmpty() || e.Name.ToLower().Contains(search.ToLower()))
                .OrderBy(e => e.Name)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Include(e => e.Offers)
                .Include(e => e.UserEmployee2Branches)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Branch>> GetBranchesWithOfferts()
        {
            return await _context.Branches
                .Include(e => e.Offers).ThenInclude(ee => ee.Car)
                .Where(e => e.Offers.Where(ee => ee.Car.IsDeleted == false).Any())
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetSearchBranchesCount(string search)
        {
            return await _context.Branches
                .Where(e => search.IsNullOrEmpty() || e.Name.ToLower().Contains(search.ToLower()))
                .CountAsync();
        }
    }
}
