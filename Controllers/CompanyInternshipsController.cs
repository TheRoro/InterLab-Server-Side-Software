using AutoMapper;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services;
using InterLab.API.Extensions;
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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveInternshipResource resource, int companyId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var internship = _mapper.Map<SaveInternshipResource, Internship>(resource);
            var result = await _internshipService.SaveAsync(internship, companyId);

            if (!result.Success)
                return BadRequest(result.Message);

            var internshipResource = _mapper.Map<Internship, InternshipResource>(result.Resource);
            return Ok(internshipResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveInternshipResource resource)
        {
            var internship = _mapper.Map<SaveInternshipResource, Internship>(resource);
            var result = await _internshipService.UpdateAsync(id, internship);

            if (!result.Success)
                return BadRequest(result.Message);
            var internshipResource = _mapper.Map<Internship, InternshipResource>(result.Resource);
            return Ok(internshipResource);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, int companyId)
        {
            var result = await _internshipService.DeleteAsync(id, companyId);

            if (!result.Success)
                return BadRequest(result.Message);
            var internshipResource = _mapper.Map<Internship, InternshipResource>(result.Resource);
            return Ok(internshipResource);
        }
    }
}
