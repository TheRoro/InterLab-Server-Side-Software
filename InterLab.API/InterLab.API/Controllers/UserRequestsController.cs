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
    [Route("/api/users/{userId}/requests")]
    public class UserRequestsController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public UserRequestsController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RequestResource>> GetAllByUserId(int userId)
        {
            var requests = await _requestService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Request>, IEnumerable<RequestResource>>(requests);
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
    }
}
