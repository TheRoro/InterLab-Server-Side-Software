using InterLab.API.Domain.Models;
using InterLab.API.Domain.Repositories;
using InterLab.API.Domain.Services;
using InterLab.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Services
{
    public class RequirementService : IRequirementService
    {
        private readonly IRequirementRepository _requirementRepository;
        private readonly IInternshipRepository _internshipRepository;
        public readonly IUnitOfWork _unitOfWork;

        public RequirementService(IRequirementRepository requirementRepository, IUnitOfWork unitOfWork, IInternshipRepository internshipRepository)
        {
            _requirementRepository = requirementRepository;
            _internshipRepository = internshipRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RequirementResponse> GetByIdAsync(int id)
        {
            var existingRequirement = await _requirementRepository.FindByIdAsync(id);

            if (existingRequirement == null)
                return new RequirementResponse("Requirement not found");
            return new RequirementResponse(existingRequirement);
        }

        public async Task<IEnumerable<Requirement>> ListAsync()
        {
            return await _requirementRepository.ListAsync();
        }
        public async Task<IEnumerable<Requirement>> ListByInternshipIdAsync(int internshipId)
        {
            return await _requirementRepository.ListByInternshipIdAsync(internshipId);
        }

        public async Task<RequirementResponse> SaveAsync(Requirement requirement, int internshipId)
        {
            try
            {
                Internship internship = await _internshipRepository.FindByIdAsync(internshipId);
                internship.Requirement = requirement;
                await _requirementRepository.AddAsync(requirement);
                await _unitOfWork.CompleteAsync();

                return new RequirementResponse(requirement);
            }
            catch (Exception ex)
            {
                return new RequirementResponse($"An error ocurred while saving the profile: {ex.Message}");
            }

        }
        public async Task<RequirementResponse> UpdateAsync(int id, Requirement requirement)
        {
            var existingRequirement = await _requirementRepository.FindByIdAsync(id);

            if (existingRequirement == null)
                return new RequirementResponse("Requirement not found");

            existingRequirement.Field = requirement.Field;
            existingRequirement.Semester = requirement.Semester;

            try
            {
                _requirementRepository.Update(existingRequirement);
                await _unitOfWork.CompleteAsync();

                return new RequirementResponse(existingRequirement);
            }
            catch (Exception ex)
            {
                return new RequirementResponse($"An error ocurred while updating requirement: {ex.Message}");
            }

        }
        public async Task<RequirementResponse> DeleteAsync(int id)
        {
            var existingRequirement = await _requirementRepository.FindByIdAsync(id);

            if (existingRequirement == null)
                return new RequirementResponse("Requirement not found");

            try
            {
                _requirementRepository.Remove(existingRequirement);
                await _unitOfWork.CompleteAsync();

                return new RequirementResponse(existingRequirement);
            }
            catch (Exception ex)
            {
                return new RequirementResponse($"An error ocurred while deleting requirement: {ex.Message}");
            }
        }
    }
}
