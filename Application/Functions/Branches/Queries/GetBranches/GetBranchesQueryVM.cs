using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Queries.GetBranches
{
    public class GetBranchesQueryVM
    {
        public BranchInGetBranchesQueryVM Branch { get; set; }

        public int OffersCount { get; set; }
        public int EmployesCount { get; set; }
    }

    public class BranchInGetBranchesQueryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
