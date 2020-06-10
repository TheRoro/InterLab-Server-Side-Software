using AutoMapper;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services;
using InterLab.API.Extensions;
using InterLab.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Controllers
{
    [Route("/api/companies/{companyId}/internships")]
    public class InternshipsController : Controller
    {
        private readonly IInternshipService _internshipService;
        private readonly IMapper _mapper;

        public InternshipsController(IInternshipService internshipService, IMapper mapper)
        {
            _internshipService = internshipService;
            _mapper = mapper;
        }

    }
}