using Application.Contracts.Persistence;
using Application.Responses;
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
    public class PaymentRepository : AsyncRepository<RentPayment>, IPaymentRepository
    {
        public PaymentRepository(RentCarsDbContext rentCarsDbContext) : base(rentCarsDbContext)
        {
        }

        public async Task DeletePaymentByRentId(int rentId)
        {
            var data = await _context.RentsPayments
                .FirstOrDefaultAsync(e => e.RentId == rentId);

            _context.RentsPayments.Remove(data);

            await _context.SaveChangesAsync();
        }

        public async Task<List<RentPayment>> GetAllPayments(int page, int pageSize, string search)
        {
            return await _context.RentsPayments
                .Include(e => e.Rent).ThenInclude(ee => ee.UserApp)
                .Where(e => search.IsNullOrEmpty() || (e.Price.ToString().ToLower().Contains(search.ToLower())))
                .OrderByDescending(e => e.Created)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetAllPaymentsCount(string search)
        {
            return await _context.RentsPayments
                .Include(e => e.Rent)
                .Where(e => search.IsNullOrEmpty() || (e.Price.ToString().ToLower().Contains(search.ToLower())))
                .CountAsync();
        }

        public async Task<RentPayment?> GetPaymentByRentId(int rentId)
        {
            return await _context.RentsPayments
                .Include(e => e.Rent)
                .FirstOrDefaultAsync(e => e.RentId == rentId);
        }

        public async Task<List<RentPayment>> GetPaymentsByUserId(int userId, int page, int pageSize, string search)
        {
            return await _context.RentsPayments
                .Include(e => e.Rent)
                .Where(e => e.Rent.UserAppId == userId)
                .Where(e => search.IsNullOrEmpty() || (e.Price.ToString().ToLower().Contains(search.ToLower())))
                .OrderByDescending(e => e.Created)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetPaymentsByUserIdCount(int userId, string search)
        {
            return await _context.RentsPayments
                .Include(e => e.Rent)
                .Where(e => e.Rent.UserAppId == userId)
                .Where(e => search.IsNullOrEmpty() || (e.Price.ToString().ToLower().Contains(search.ToLower())))
                .CountAsync();
        }
    }
}
