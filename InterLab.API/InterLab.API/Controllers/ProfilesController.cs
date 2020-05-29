using AutoMapper;
using InterLab.API.Domain.Services;
using InterLab.API.Extensions;
using InterLab.API.Resources;
using InterLab.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterLab.API.Controllers
{

    [Route("/api/[controller]")]
    public class ProfilesController : Controller
    {
        private readonly IProfileService _profileService; 
        private readonly IMapper _mapper;

        public ProfilesController(IProfileService profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAsync(int id)
        //{
        //    var result = await _profileService.GetByIdAsync(id);
        //    if (!result.Success)
        //        return BadRequest(result.Message);
        //    var profileResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);
        //    return Ok(profileResource);
        //}

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var profile = _mapper.Map<SaveProfileResource, Domain.Models.Profile>(resource);
            var result = await _profileService.SaveAsync(profile);

            if (!result.Success)
                return BadRequest(result.Message);

            var profileResources = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);
            return Ok(profileResources);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _profileService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var profileResource = _mapper.Map<Domain.Models.Profile, SaveProfileResource>(result.Resource);
            return Ok(profileResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfileResource resource)
        {
            var profiles = _mapper.Map<SaveProfileResource, Domain.Models.Profile>(resource);
            var result = await _profileService.UpdateAsync(id, profiles);

            if (!result.Success)
                return BadRequest(result.Message);
            var profileResource = _mapper.Map<Domain.Models.Profile, SaveProfileResource>(result.Resource);
            return Ok(profileResource);


        }
    }


}
