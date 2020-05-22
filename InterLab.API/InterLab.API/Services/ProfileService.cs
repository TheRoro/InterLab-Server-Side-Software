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
        public readonly IUnitOfWork _unitOfWork;

        public ProfileService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
        {
            _profileRepository = profileRepository;
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

        public  Task<Profile> GetByIdAndStudentId(int id, int studentId)
        {
            throw new NotImplementedException();
        }

        public  Task<Profile> GetByIdAndWorkerId(int id, int workerId)
        {
            throw new NotImplementedException();
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

        public async Task<ProfileResponse> SaveAsync(Profile profile)
        {
            try
            {
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
            var existingProfile = await _profileRepository.FindById(id);

            if (existingProfile == null)
                return new ProfileResponse("Profile not found");

            existingProfile.FirstName = profile.FirstName;
            existingProfile.LastName = profile.LastName;
            existingProfile.Phone = profile.Phone;
            existingProfile.Country = profile.Country;
            existingProfile.City = profile.City;

            try
            {
                _profileRepository.Update(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(existingProfile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while updating profile:  {ex.Message}");
            }
        }

        //public async Task<IEnumerable<Profile>> ListByStudentId(int studentId)
        //{
        //    return await _profileRepository.ListByStudentId(studentId);
        //}

        //public async Task<IEnumerable<Profile>> ListByWorkerId(int workerId)
        //{
        //    return await _profileRepository.ListByWorkerId(workerId);
        //}
    }
}
