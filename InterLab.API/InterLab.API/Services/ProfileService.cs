using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Repositories;
using InterLab.API.Domain.Services;
using InterLab.API.Domain.Services.Communication;

namespace InterLab.API.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        
        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public Task<ProfileResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Terminado
        public async Task<IEnumerable<Profile>> ListAsync()
        {
            return await _profileRepository.ListAsync();
        }

        public Task<ProfileResponse> SaveAsync(Profile profile)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileResponse> UpdateAsync(int id, Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}
