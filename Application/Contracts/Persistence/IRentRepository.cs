using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IRentRepository : IAsyncRepository<Rent>
    {
        Task<Rent> AddRent(Rent rent);
        Task<List<Rent>> GetRentsByUserId(int userId, int page, int pageSize, string search);
        Task<int> GetRentsByUserIdCount(int userId, string search);
        Task<List<Rent>> GetAllRents(int page, int pageSize, string search);
        Task<int> GetAllRentsCount(string search);
        Task<Rent> GetWithPayment(int rentId);
    }
}
