using AutoMapper;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services;
using InterLab.API.Extensions;
using InterLab.API.Resources;
using InterLab.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterLab.API.Controllers
{

    [Route("/api/profiles")]
    public class ProfilesController : Controller
    {
        private readonly IProfileService _profileService; 
        private readonly IMapper _mapper;

        public ProfilesController(IProfileService profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProfileResource>> GetAllAsync()
        {
            var profiles = await _profileService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Domain.Models.Profile>, IEnumerable<ProfileResource>>(profiles);
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

        //[HttpPost]
        //public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState.GetErrorMessages());
        //    var profile = _mapper.Map<SaveProfileResource, Domain.Models.Profile>(resource);
        //    var result = await _profileService.SaveAsync(profile);

        //    if (!result.Success)
        //        return BadRequest(result.Message);

        //    var profileResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);
        //    return Ok(profileResource);
        //}
    }
}
