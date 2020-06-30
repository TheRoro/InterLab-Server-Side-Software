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
    [Route("/api/users/{userId}/companies")]
    public class UserCompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IUserCompanyService _userCompanyService;
        private readonly IMapper _mapper;

        public UserCompaniesController(ICompanyService companyService, IUserCompanyService userCompanyService, IMapper mapper)
        {
            _companyService = companyService;
            _userCompanyService = userCompanyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyResource>> GetAllByUserIdAsync(int userId)
        {
            var companies = await _companyService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
            return resources;
        }

        [HttpPost("{companyId}")]
        public async Task<IActionResult> AssignUserCompany(int userId, int companyId)
        {

            var result = await _userCompanyService.AssignUserCompanyAsync(userId, companyId);
            if (!result.Success)
                return BadRequest(result.Message);

            var tagResource = _mapper.Map<Company, CompanyResource>(result.Resource.Company);
            return Ok(tagResource);
        }

        [HttpDelete("{companyId}")]
        public async Task<IActionResult> UnassignUserCompanyAsync(int userId, int companyId) 
        {
            var result = await _userCompanyService.UnassignUserCompanyAsync(userId, companyId);
            if (!result.Success)
                return BadRequest(result.Message);

            var tagResource = _mapper.Map<Company, CompanyResource>(result.Resource.Company);
            return Ok(tagResource);
        }
    }
}
