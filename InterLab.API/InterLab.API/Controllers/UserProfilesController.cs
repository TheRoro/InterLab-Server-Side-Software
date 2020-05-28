using AutoMapper;
using InterLab.API.Domain.Services;
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

    }
}
