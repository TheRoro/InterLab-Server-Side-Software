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
            CreateMap<Company, CompanyResource>();
            CreateMap<Document, DocumentResource>();
            CreateMap<Internship, InternshipResource>();
            CreateMap<Profile, ProfileResource>();
            CreateMap<Qualification, QualificationResource>();
            CreateMap<Request, RequestResource>();
            CreateMap<Requirement, RequirementResource>();
            CreateMap<User, UserResource>();
        }
    }
}
