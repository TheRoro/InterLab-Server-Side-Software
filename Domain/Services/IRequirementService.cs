using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services
{
    public interface IRequirementService
    {
        Task<RequirementResponse> GetByIdAsync(int id);

        Task<IEnumerable<Requirement>> ListAsync();
        Task<IEnumerable<Requirement>> ListByInternshipIdAsync(int internshipId);

        Task<RequirementResponse> SaveAsync(Requirement requirement, int internshipId);
        Task<RequirementResponse> UpdateAsync(int id, Requirement requirement);
        Task<RequirementResponse> DeleteAsync(int id);
    }
}
