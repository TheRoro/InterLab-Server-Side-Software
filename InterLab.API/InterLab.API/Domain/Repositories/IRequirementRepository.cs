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
        Task Add(Requirement requirement);
        Task<Requirement> FindByIdAsync(int id);
        void Update(Requirement requirement);
        void Remove(Requirement requirement);
    }
}
