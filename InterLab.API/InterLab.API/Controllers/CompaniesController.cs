using AutoMapper;
using InterLab.API.Domain.Services;
using InterLab.API.Domain.Models;
using InterLab.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterLab.API.Extensions;

namespace InterLab.API.Controllers
{
    [Route("/api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyResource>> GetAllAsync()
        {
            var companies = await _companyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _companyService.GetById(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var profileResource = _mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(profileResource);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCompanyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var request = _mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await _companyService.SaveAsync(request);

            if (!result.Success)
                return BadRequest(result.Message);

            var userRequest = _mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(userRequest);
        }
    }
}
