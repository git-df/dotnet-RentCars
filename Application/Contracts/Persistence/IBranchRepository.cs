using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IBranchRepository : IAsyncRepository<Branch>
    {
        Task<List<Branch>> GetBranchesWithAdresses();
        Task<List<Branch>> GetBranchesWithCountOfReferences(int page, int pageSize, string search);
        Task<Branch> GetBranchByIdWithAddress(int id);
        Task<Branch> GetBranchByIdWithAllReferences(int id);
        Task<int> GetSearchBranchesCount(string search);
        Task<List<Branch>> GetBranchesWithOfferts();
    }
}
