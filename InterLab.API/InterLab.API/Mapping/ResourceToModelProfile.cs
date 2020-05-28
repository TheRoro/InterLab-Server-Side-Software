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
            CreateMap<SaveCompanyResource, Company>();
            CreateMap<SaveDocumentResource, Document>();
            CreateMap<SaveInternshipResource, Internship>();
            CreateMap<SaveProfileResource, Domain.Models.Profile>();
            CreateMap<SaveQualificationResource, Qualification>();
            CreateMap<SaveRequestResource, Request>();
            CreateMap<SaveRequirementResource, Requirement>();
            CreateMap<SaveUserResource, User>();
        }
    }
}
