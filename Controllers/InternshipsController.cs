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
    [Route("/api/internships")]
    public class InternshipsController : Controller
    {
        private readonly IInternshipService _internshipService;
        private readonly IMapper _mapper;

        public InternshipsController(IInternshipService internshipService, IMapper mapper)
        {
            _internshipService = internshipService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<InternshipResource>> GetAllAsync()
        {
            var internships = await _internshipService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Internship>, IEnumerable<InternshipResource>>(internships);
            return resources;
        }
    }
}