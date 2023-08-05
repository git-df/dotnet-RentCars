﻿using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Commands.DeleteBranch
{
    public class DeleteBranchCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
