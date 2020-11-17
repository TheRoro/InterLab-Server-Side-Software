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
using Microsoft.AspNetCore.Authorization;
using InterLab.API.Domain.Services.Communication;
using Renci.SshNet.Messages;
using InterLab.API.Extensions;

namespace InterLab.API.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;   
        private readonly IMapper _mapper; 

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _userService.GetById(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var profileResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(profileResource);
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest request)
        {
            var response = _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Invalid Username or Password" });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var request = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.SaveAsync(request);

            if (!result.Success)
                return BadRequest(result.Message);

            var userRequest = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userRequest);
        }

    }

}
