using AutoMapper;
using InterLab.API.Domain.Models;
using InterLab.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Profile = InterLab.API.Domain.Models.Profile;

namespace InterLab.API.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<Company, CompanyResource>();
            CreateMap<Internship, InternshipResource>();
            CreateMap<Profile, ProfileResource>();
        }
    }
}
