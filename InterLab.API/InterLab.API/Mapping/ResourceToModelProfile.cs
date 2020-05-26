using AutoMapper;
using InterLab.API.Domain.Models;
using InterLab.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveProfileResource, Domain.Models.Profile>();
            //duda para Company;
        }
    }
}
