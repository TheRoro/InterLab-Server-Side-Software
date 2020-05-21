using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services.Communication
{
    public class RequirementResponse : BaseResponse
    {
        public Requirement Requirement { get; private set; }

        public RequirementResponse(bool success, string message, Requirement requirement) : base(success, message)
        {
            Requirement = requirement;
        }

        public RequirementResponse(Requirement requirement) : this(true, string.Empty, requirement) { }
        
        public RequirementResponse(string message) : this(false, message, null) { }
    }
}
