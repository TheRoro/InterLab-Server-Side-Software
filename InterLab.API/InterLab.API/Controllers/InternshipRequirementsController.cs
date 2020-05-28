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
    [Route("/api/internships/{internshipId}/requirements")]
    public class InternshipRequirementsController : Controller
    {
        private readonly IRequirementService _requirementService;
        private readonly IMapper _mapper;

        public InternshipRequirementsController(IRequirementService requirementService, IMapper mapper)
        {
            _requirementService = requirementService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RequirementResource>> GetByInternshipIdAsync(int internshipId)
        {
            var requirements = await _requirementService.ListByInternshipIdAsync(internshipId);
            var resources = _mapper
                .Map<IEnumerable<Requirement>, IEnumerable<RequirementResource>>(requirements);
            return resources;
        }
    }
}
