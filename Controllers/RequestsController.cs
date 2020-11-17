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
    public class RequestsController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestsController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
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

            var requestService = _mapper.Map<Request, RequestResource>(result.Resource);
            return Ok(requestService);
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