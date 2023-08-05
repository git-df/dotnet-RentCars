using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Queries.GetBranchDetails
{
    public class GetBranchDetailsQueryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public AddressInGetBranchDetailsQueryVM Address { get; set; }
    }

    public class AddressInGetBranchDetailsQueryVM
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetWithNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
