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
    public class RequestsController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestsController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RequestResource>> GetAllAsync()
        {
            var requests = await _requestService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Request>, IEnumerable<RequestResource>>(requests);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _requestService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var requestResource = _mapper.Map<Request, RequestResource>(result.Resource);
            return Ok(requestResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRequestResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var request = _mapper.Map<SaveRequestResource, Request>(resource);
            var result = await _requestService.SaveAsync(request);

            if (!result.Success)
                return BadRequest(result.Message);

            var requestResource = _mapper.Map<Request, SaveRequestResource>(result.Resource);
            return Ok(requestResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRequestResource resource)
        {
            var request = _mapper.Map<SaveRequestResource, Request>(resource);
            var result = await _requestService.UpdateAsync(id, request);

            if (!result.Success)
                return BadRequest(result.Message);
            var requestResource = _mapper.Map<Request, RequestResource>(result.Resource);
            return Ok(requestResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _requestService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var requestResource = _mapper.Map<Request, RequestResource>(result.Resource);
            return Ok(requestResource);
        }
    }
}