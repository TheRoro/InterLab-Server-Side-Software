using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services
{
    public interface ICompanyService
    {
        Task<CompanyResponse> GetById(int id);
        Task<IEnumerable<Company>> ListAsync();
        Task<CompanyResponse> SaveAsync(Company company);
        Task<CompanyResponse> UpdateAsync(int id, Company company);
        Task<CompanyResponse> DeleteAsync(int id);
        Task<IEnumerable<Company>> ListByUserIdAsync(int userId);
    }
}
