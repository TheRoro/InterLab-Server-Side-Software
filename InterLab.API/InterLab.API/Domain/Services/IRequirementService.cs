﻿using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services
{
    public interface IRequirementService
    {
        Task<IEnumerable<Requirement>> ListAsync();
        Task<RequirementResponse> GetByIdAsync(int id);
        Task<RequirementResponse> SaveAsync(Requirement requirement);
        Task<RequirementResponse> UpdateAsync(int id, Requirement requirement);
        Task<RequirementResponse> DeleteAsync(int id);
    }
}
