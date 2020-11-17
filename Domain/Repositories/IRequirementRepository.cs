using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IRequirementRepository
    {
        Task<Requirement> FindByIdAsync(int id);

        Task<IEnumerable<Requirement>> ListAsync();
        Task<IEnumerable<Requirement>> ListByInternshipIdAsync(int internshipId);

        Task AddAsync(Requirement requirement);
        void Update(Requirement requirement);
        void Remove(Requirement requirement);
    }
}
