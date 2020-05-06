using AutoMapper;
using InterLab.API.Domain.Models;
using InterLab.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Student, StudentResource>();
            CreateMap<Company, CompanyResource>();
            CreateMap<Internship, InternshipResource>();
        }
    }
}
