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

    [Route("/api/users/{userId}/profiles")] 
    public class UserProfilesController : Controller
    { 
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;


        public UserProfilesController(IProfileService profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProfileResource>> GetByUserId(int userId)   
        {
            var profiles = await _profileService.ListByUserId(userId);
            var resources = _mapper
                .Map<IEnumerable<Domain.Models.Profile>, IEnumerable<ProfileResource>>(profiles);
            return resources;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _profileService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var profileResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);
            return Ok(profileResource);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var profile = _mapper.Map<SaveProfileResource, Domain.Models.Profile>(resource);
            var result = await _profileService.SaveAsync(profile, userId);

            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);
            return Ok(profileResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _profileService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var profileResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);
            return Ok(profileResource);
        }


        [HttpPut]
        public async Task<IActionResult> PutAsync(int userId, [FromBody] SaveProfileResource resource)
        {
            var profiles = _mapper.Map<SaveProfileResource, Domain.Models.Profile>(resource);
            var result = await _profileService.UpdateAsync(userId, profiles);

            if (!result.Success)
                return BadRequest(result.Message);
            var profileResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);
            return Ok(profileResource);


        }
    }
}
