using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterLab.API.Domain.IRepositories;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Repositories;
using InterLab.API.Domain.Services;
using InterLab.API.Domain.Services.Communication;

namespace InterLab.API.Services
{
    public class ProfileService : IProfileService
    {

        private readonly IProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ProfileService(IProfileRepository profileRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _profileRepository = profileRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfileResponse> DeleteAsync(int id)
        {
            var existingProfile = await _profileRepository.FindById(id);

            if (existingProfile == null)
                return new ProfileResponse("Profile not found");

            try 
            {
                _profileRepository.Remove(existingProfile);
                await _unitOfWork.CompleteAsync();
                return new ProfileResponse(existingProfile);
            }
            catch(Exception ex)
            {
                return new ProfileResponse($"An error ocurred while deleting profile:  {ex.Message}");
            }

        }

        public async Task<ProfileResponse> GetByIdAsync(int id)
        {
            var existingProfile = await _profileRepository.FindById(id);

            if (existingProfile == null)
                return new ProfileResponse("Profile not found");
            return new ProfileResponse(existingProfile);
        }

        public async Task<IEnumerable<Profile>> ListAsync()
        {
            return await _profileRepository.ListAsync();
        }

        public async Task<ProfileResponse> SaveAsync(Profile profile, int userId)
        {
            try
            {
                User user = await _userRepository.FindByIdAsync(userId);
                user.Profile = profile;
                await _profileRepository.AddAsync(profile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(profile);
            }
            catch(Exception ex)
            {
                return new ProfileResponse($"An error ocurred while saving the profile: {ex.Message}");
            }

        }

        public async Task<ProfileResponse> UpdateAsync(int id, Profile profile)
        {
            IEnumerable<Profile> existingProfile = await _profileRepository.ListByUserId(id);
           

            if (existingProfile == null)
                return new ProfileResponse("User not registred");

            existingProfile.First().FirstName = profile.FirstName;
            existingProfile.First().LastName = profile.LastName;
            existingProfile.First().Phone = profile.Phone;
            existingProfile.First().Country = profile.Country;
            existingProfile.First().City = profile.City;
            existingProfile.First().Field = profile.Field;
            existingProfile.First().Description = profile.Description;
            existingProfile.First().University = profile.University;
            existingProfile.First().Degree = profile.Degree;
            existingProfile.First().Semester = profile.Semester;
            try
            {
                _profileRepository.Update(existingProfile.First());
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(existingProfile.First());
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while updating profile:  {ex.Message}");
            }
        }

        public Task<Profile> GetByIdAndUsertId(int id, int userId) 
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Profile>> ListByUserId(int userId)
        {
            return await _profileRepository.ListByUserId(userId);
        }
    }
}
