using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services;
using InterLab.API.Controllers;
using AutoMapper;
using InterLab.API.Persistence.Repositories;
using InterLab.API.Resources;

namespace InterLab.API.Controllers
{
    [Route("/api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;   
        private readonly IMapper _mapper; 


        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _userService.GetById(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var profileResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(profileResource);
        }

    }

}
