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
    [Route("/api/companies/{companyId}/qualifications")]
    public class CompanyQualificationsController : Controller
    {
        private readonly IQualificationService _qualificationService;
        private readonly IMapper _mapper;

        public CompanyQualificationsController(IQualificationService qualificationService, IMapper mapper)
        {
            _qualificationService = qualificationService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _qualificationService.GetById(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var qualificationResource = _mapper.Map<Qualification, QualificationResource>(result.Resource);
            return Ok(qualificationResource);

        }

        [HttpGet]
        public async Task<IEnumerable<QualificationResource>> GetAllByCompanyId(int companyId)
        {
            var qualifications = await _qualificationService.ListByCompanyIdAsync(companyId);
            var resources = _mapper
                .Map<IEnumerable<Qualification>, IEnumerable<QualificationResource>>(qualifications);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveQualificationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var qualification = _mapper.Map<SaveQualificationResource, Qualification>(resource);
            var result = await _qualificationService.SaveAsync(qualification);

            if (!result.Success)
                return BadRequest(result.Message);

            var qualificationResource = _mapper.Map<Qualification, QualificationResource>(result.Resource);
            return Ok(qualificationResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveQualificationResource resource)
        {
            var qualification = _mapper.Map<SaveQualificationResource, Qualification>(resource);
            var result = await _qualificationService.UpdateAsync(id, qualification);

            if (!result.Success)
                return BadRequest(result.Message);
            var qualificationResource = _mapper.Map<Qualification, QualificationResource>(result.Resource);
            return Ok(qualificationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _qualificationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var qualificationResource = _mapper.Map<Qualification, QualificationResource>(result.Resource);
            return Ok(qualificationResource);
        }
    }
}
