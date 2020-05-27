using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IRequirementRepository
    {
        Task<IEnumerable<Requirement>> ListAsync();
        Task AddAsync(Requirement requirement);
        Task<Requirement> FindByIdAsync(int id);
        Task<IEnumerable<Requirement>> ListByInternshipIdAsync(int internshipId);
        void Update(Requirement requirement);
        void Remove(Requirement requirement);
    }
}
