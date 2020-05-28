using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterLab.API.Domain.Services.Communication;

namespace InterLab.API.Domain.Services
{
    public interface IInternshipService
    {

        Task<IEnumerable<Internship>> ListAsync();
        Task<IEnumerable<Internship>> ListByCompanyIdAsync(int companyId);

        Task<InternshipResponse> GetByIdAndCompanyIdAsync(int id, int companyId);

        Task<InternshipResponse> GetByIdAsync(int id);

        Task<InternshipResponse> SaveAsync(Internship internship);
        Task<InternshipResponse> UpdateAsync(int id, Internship internship);
        Task<InternshipResponse> DeleteAsync(int id);
    }
}
