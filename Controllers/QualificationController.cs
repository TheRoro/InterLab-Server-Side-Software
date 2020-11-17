using AutoMapper;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services;
using InterLab.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Controllers
{
    [Route("/api/[controller]")]
    public class QualificationsController : Controller
    {
        private readonly IQualificationService _qualificationService;
        private readonly IMapper _mapper;

        public QualificationsController(IQualificationService qualificationService, IMapper mapper)
        {
            _qualificationService = qualificationService;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<IEnumerable<QualificationResource>> GetAllAsync()
        //{
        //    var qualifications = await _qualificationService.Lis();
        //    var resources = _mapper
        //        .Map<IEnumerable<Qualification>, IEnumerable<CategoryResource>>(categories);
        //    return resources;
        //}

    }
}