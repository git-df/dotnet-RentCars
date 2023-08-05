using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IPaymentRepository : IAsyncRepository<RentPayment>
    {
        Task<List<RentPayment>> GetPaymentsByUserId(int userId, int page, int pageSize, string search);
        Task<int> GetPaymentsByUserIdCount(int userId, string search);
        Task<List<RentPayment>> GetAllPayments(int page, int pageSize, string search);
        Task<int> GetAllPaymentsCount(string search);
        Task DeletePaymentByRentId(int rentId);
        Task<RentPayment> GetPaymentByRentId(int rentId);
    }
}
