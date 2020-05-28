using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IInternshipRepository
    {

        Task<IEnumerable<Internship>> ListAsync();

        Task<Internship> FindByCompanyIdAndIntershipIdAsynd(int companyId, int Id); 

        Task<Internship> FindById(int id);

        Task AddAsync(Internship internship);

        Task<IEnumerable<Internship>> ListByCompanyIdAsync(int companyId);
        void Update(Internship internship);
        void Remove(Internship internship); 
    }
}
