using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IOfferRepository : IAsyncRepository<Offer>
    {
        Task<List<Offer>> GetOffers(int page, int pageSize, string search);
        Task<int> GetOffersCount(string search);
        Task<Offer> GetOfferByCarAndBranch(int carId, int brancId);
    }
}
