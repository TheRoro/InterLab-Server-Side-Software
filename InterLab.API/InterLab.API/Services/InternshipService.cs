using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterLab.API.Domain.Services;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Repositories;

namespace InterLab.API.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly IInternshipRepository _internshipRepository;

        InternshipService(IInternshipRepository internshipRepository)
        {
            _internshipRepository = internshipRepository;
        }
        public async Task<IEnumerable<Internship>> ListAsync()
        {
            return await _internshipRepository.ListAsync();
        }
    }
}
