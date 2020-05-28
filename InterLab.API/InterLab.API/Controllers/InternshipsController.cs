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
    public class InternshipsController : Controller
    {
        private readonly IInternshipService _internshipService;
        private readonly IMapper _mapper;

        public InternshipsController(IInternshipService internshipService, IMapper mapper)
        {
            _internshipService = internshipService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<InternshipResource>> GetAllAsync()
        {
            var internships = await _internshipService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Internship>, IEnumerable<InternshipResource>>(internships);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _internshipService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var intershipResource = _mapper.Map<Internship, InternshipResource>(result.Resource);
            return Ok(intershipResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveInternshipResource resource)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var intership = _mapper.Map<SaveInternshipResource, Internship>(resource); 
            var result = await _internshipService.SaveAsync(intership);

            if (!result.Success)
                return BadRequest(result.Message);

            var intershipResource = _mapper.Map<Internship, InternshipResource>(result.Resource);
            return Ok(intershipResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _internshipService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var intershipResource = _mapper.Map<Internship, SaveInternshipResource>(result.Resource);
            return Ok(intershipResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveInternshipResource resource)
        {
            var intership = _mapper.Map<SaveInternshipResource, Internship>(resource);
            var result = await _internshipService.UpdateAsync(id, intership);

            if (!result.Success)
                return BadRequest(result.Message);
            var internshipResource = _mapper.Map<Internship, SaveInternshipResource>(result.Resource);
            return Ok(internshipResource);


        }
    }
}