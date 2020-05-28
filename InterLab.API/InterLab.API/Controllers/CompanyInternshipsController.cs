using AutoMapper;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services;
using InterLab.API.Resources;
using InterLab.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Controllers
{

    [Route("/api/companies/{companyId}/internships")]
    public class CompanyInternshipsController : Controller
    {
        private readonly IInternshipService _internshipService;
        private readonly IMapper _mapper;

        public CompanyInternshipsController(IInternshipService internshipService, IMapper mapper)
        {
            _internshipService = internshipService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<InternshipResource>> GetAllByCompanyId(int companyId)
        {
            var internships = await _internshipService.ListByCompanyIdAsync(companyId);
            var resources = _mapper
            .Map<IEnumerable<Internship>, IEnumerable<InternshipResource>> (internships);
            return resources;

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetInternshipsByIdAsync(int id)
        {
            var result = await _internshipService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var internshipResource = _mapper.Map<Internship, InternshipResource>(result.Resource);
            return Ok(internshipResource);
        }


    }
}
