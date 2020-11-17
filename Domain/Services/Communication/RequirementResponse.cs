using InterLab.API.Domain.Models;
using InterLab.API.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services.Communication
{
    public class RequirementResponse : BaseResponse<Requirement>
    {
        public RequirementResponse(Requirement requirement) : base(requirement) { }

        public RequirementResponse(string message) : base(message) { }
    }
}
