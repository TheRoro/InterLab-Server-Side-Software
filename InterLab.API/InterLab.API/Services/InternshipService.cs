using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterLab.API.Domain.Services;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Repositories;
using InterLab.API.Domain.Services.Communication;

namespace InterLab.API.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly IInternshipRepository _internshipRepository;
        public readonly IUnitOfWork _unitOfWork;

        public InternshipService(IInternshipRepository internshipRepository, IUnitOfWork unitOfWork)
        {
            _internshipRepository = internshipRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InternshipResponse> DeleteAsync(int id)
        {
            var existingIntership = await _internshipRepository.FindById(id);

            if (existingIntership == null)
                return new InternshipResponse("Intership not found"); 

            try
            {
                _internshipRepository.Remove(existingIntership);
                await _unitOfWork.CompleteAsync();
                return new InternshipResponse(existingIntership);
            }
            catch (Exception ex)
            {
                return new InternshipResponse($"An error ocurred while deleting intership:  {ex.Message}");
            }
        }

        public async Task<InternshipResponse> GetByIdAsync(int id)
        {
            var existingIntership = await _internshipRepository.FindById(id);

            if (existingIntership == null)
                return new InternshipResponse("Profile not found");
            return new InternshipResponse(existingIntership);
        }

        public async Task<IEnumerable<Internship>> ListByCompanyIdAsync(int companyId)
        {
            return await _internshipRepository.ListByCompanyIdAsync(companyId); 
        }

        public async Task<InternshipResponse> SaveAsync(Internship internship)
        {
            try
            {
                await _internshipRepository.AddAsync(internship);
                await _unitOfWork.CompleteAsync();

                return new InternshipResponse(internship);
            }
            catch (Exception ex)
            {
                return new InternshipResponse($"An error ocurred while saving the intership: {ex.Message}");
            }
        }

        public async Task<InternshipResponse> UpdateAsync(int id, Internship internship)
        {
            var existingIntership = await _internshipRepository.FindById(id);

            if (existingIntership == null)
                return new InternshipResponse("Intership not found");

            existingIntership.Description = internship.Description;
            existingIntership.Salary = internship.Salary;

            try
            {
                _internshipRepository.Update(existingIntership);
                await _unitOfWork.CompleteAsync();

                return new InternshipResponse(existingIntership);
            }
            catch (Exception ex)
            {
                return new InternshipResponse($"An error ocurred while updating intership:  {ex.Message}");
            }
        }

        public async Task<InternshipResponse> GetByIdAndCompanyIdAsync(int id, int companyId)
        {
            var existingIntership = await _internshipRepository.FindByCompanyIdAndIntershipIdAsynd(id, companyId);

            if (existingIntership == null)
                return new InternshipResponse("Intership not found");
            return new InternshipResponse(existingIntership);
        }

        public async Task<IEnumerable<Internship>> ListAsync()
        {
            return await _internshipRepository.ListAsync();
        }

    }
}
