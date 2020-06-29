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
    [Route("/api/users/{userId}/internships")]
    public class UserRequestsController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IInternshipService _internshipService;
        private readonly IMapper _mapper;

        public UserRequestsController(IRequestService requestService, IInternshipService internshipService, IMapper mapper)
        {
            _requestService = requestService;
            _internshipService = internshipService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<InternshipResource>> GetAllByUserIdAsync(int userId)
        {
            var internships = await _internshipService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Internship>, IEnumerable<InternshipResource>>(internships);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestByIdAsync(int id)
        {
            var result = await _requestService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var requestResource = _mapper.Map<Request, RequestResource>(result.Resource);
            return Ok(requestResource);

        }

        [HttpPost("{internshipId}")]
        public async Task<IActionResult> AssignUserInternship(int userId, int internshipId)
        {

            var result = await _requestService.AssignUserInternshipAsync(userId, internshipId);
            if (!result.Success)
                return BadRequest(result.Message);

            var Resource = _mapper.Map<Internship, InternshipResource>(result.Resource.Internship);
            return Ok(Resource);
        }
    }
}
