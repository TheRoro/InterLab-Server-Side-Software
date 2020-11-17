using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services.Communication
{
    public class ProfileResponse : BaseResponse<Profile>
    {
        public ProfileResponse(Profile profile) : base(profile) { }

        public ProfileResponse(string message) : base(message) { }
    }
}
