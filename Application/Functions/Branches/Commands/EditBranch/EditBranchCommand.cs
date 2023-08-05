using Application.Functions.Branches.Queries.GetBranchDetails;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Commands.EditBranch
{
    public class EditBranchCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public AddressInEditBranchCommand Address { get; set; }
    }

    public class AddressInEditBranchCommand
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetWithNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
