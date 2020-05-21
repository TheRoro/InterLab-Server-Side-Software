using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> ListAsync();

        Task<ProfileResponse> GetByIdAsync(int id);

        Task<ProfileResponse> SaveAsync(Profile profile);

        Task<ProfileResponse> UpdateAsync(int id, Profile profile);

        Task<ProfileResponse> DeleteAsync(int id);
    }
}
