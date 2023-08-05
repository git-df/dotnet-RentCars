using Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Commands.AddBranch
{
    public class AddBranchCommand : IRequest<BaseResponse>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public AddressInAddBranchCommand Address { get; set; }
    }

    public class AddressInAddBranchCommand
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetWithNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
