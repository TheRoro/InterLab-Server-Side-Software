﻿using AutoMapper;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services;
using InterLab.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Controllers
{
    [Route("/api/internships/{internshipId}/requests")]
    public class InternshipRequestsController
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public InternshipRequestsController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RequestResource>> GetAllByInternshipIdAsync(int internshipId)
        {
            var requests = await _requestService.ListByInternshipIdAsync(internshipId);
            var resources = _mapper
                .Map<IEnumerable<Request>, IEnumerable<RequestResource>>(requests);
            return resources;
        }
    }
}
