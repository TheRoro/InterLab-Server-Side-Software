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
    [Route("/api/[controller]")]
    public class RequirementsController : Controller
    {
        private readonly IRequirementService _requirementService;
        private readonly IMapper _mapper;

        public RequirementsController(IRequirementService requirementService, IMapper mapper)
        {
            _requirementService = requirementService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RequirementResource>> GetAllAsync()
        {
            var requirements = await _requirementService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Requirement>, IEnumerable<RequirementResource>>(requirements);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _requirementService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var requirementResource = _mapper.Map<Requirement, RequirementResource>(result.Resource);
            return Ok(requirementResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRequirementResource resource)
        {
            var requirement = _mapper.Map<SaveRequirementResource, Requirement>(resource);
            var result = await _requirementService.UpdateAsync(id, requirement);

            if (!result.Success)
                return BadRequest(result.Message);
            var requirementResource = _mapper.Map<Requirement, RequirementResource>(result.Resource);
            return Ok(requirementResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _requirementService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var requirementResource = _mapper.Map<Requirement, RequirementResource>(result.Resource);
            return Ok(requirementResource);
        }
    }
}
