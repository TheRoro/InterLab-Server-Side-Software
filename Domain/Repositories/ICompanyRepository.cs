using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> FindById(int id);
        Task<IEnumerable<Company>> ListAsync();
        Task AddAsync(Company company);
        void Remove(Company company);
        void Update(Company company);
    }
}
