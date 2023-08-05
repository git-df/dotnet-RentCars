using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Queries.GetContacts
{
    public class GetContactsQueryVM
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public AddressInGetContactsQueryVM Address { get; set; }
    }

    public class AddressInGetContactsQueryVM
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetWithNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
