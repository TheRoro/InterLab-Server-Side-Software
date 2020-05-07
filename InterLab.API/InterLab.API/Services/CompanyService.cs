using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterLab.API.Domain.Services;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Repositories;

namespace InterLab.API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _companyRepository.ListAsync();
        }
    }
}
