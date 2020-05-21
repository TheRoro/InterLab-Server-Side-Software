using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterLab.API.Domain.Models;

namespace InterLab.API.Domain.Services.Communication
{
    public class ProfileResponse : BaseResponse
    {
        public Models.Profile Profile { get; private set; }

        public ProfileResponse (bool success, string message, Models.Profile profile) : base(success, message)
        {
            Profile = profile;
        }

        public ProfileResponse(Models.Profile profile) : this(true, string.Empty, profile ) {  }

        public ProfileResponse(string message) : this(false, message, null) { }
    }
}
