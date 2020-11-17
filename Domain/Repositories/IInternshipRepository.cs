using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IInternshipRepository
    {
        Task<Internship> FindByIdAsync(int id);
        Task<Internship> FindByCompanyIdAndIntershipIdAsynd(int companyId, int Id);

        Task<IEnumerable<Internship>> ListAsync();
        Task<IEnumerable<Internship>> ListByCompanyIdAsync(int companyId);

        Task AddAsync(Internship internship);
        void Update(Internship internship);
        void Remove(Internship internship); 
    }
}
