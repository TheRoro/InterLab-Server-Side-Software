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
        private readonly ICompanyRepository _companyRepository;
        private readonly IRequestRepository _requestRepository;
        public readonly IUnitOfWork _unitOfWork;

        public InternshipService(IInternshipRepository internshipRepository, ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IRequestRepository requestRepository)
        {
            _internshipRepository = internshipRepository;
            _requestRepository = requestRepository;
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InternshipResponse> GetByIdAsync(int id)
        {
            var existingIntership = await _internshipRepository.FindByIdAsync(id);

            if (existingIntership == null)
                return new InternshipResponse("Internship not found");
            return new InternshipResponse(existingIntership);
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
        public async Task<IEnumerable<Internship>> ListByCompanyIdAsync(int companyId)
        {
            return await _internshipRepository.ListByCompanyIdAsync(companyId);
        }


        public async Task<InternshipResponse> SaveAsync(Internship internship, int companyId)
        {
            try
            {
                Company company = await _companyRepository.FindById(companyId);
                company.Internships.Add(internship);
                await _internshipRepository.AddAsync(internship);
                await _unitOfWork.CompleteAsync();

                return new InternshipResponse(internship);
            }
            catch (Exception ex)
            {
                return new InternshipResponse($"An error ocurred while saving the internship: {ex.Message}");
            }
        }

        public async Task<InternshipResponse> UpdateAsync(int id, Internship internship)
        {
            var existingIntership = await _internshipRepository.FindByIdAsync(id);

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
        public async Task<InternshipResponse> DeleteAsync(int id, int companyId)
        {
            var existingIntership = await _internshipRepository.FindByIdAsync(id);

            if (existingIntership == null)
                return new InternshipResponse("Internship not found");

            try
            {
                Company company = await _companyRepository.FindById(companyId);
                company.Internships.Remove(existingIntership);
                _internshipRepository.Remove(existingIntership);
                await _unitOfWork.CompleteAsync();
                return new InternshipResponse(existingIntership);
            }
            catch (Exception ex)
            {
                return new InternshipResponse($"An error ocurred while deleting internship:  {ex.Message}");
            }
        }

        public async Task<IEnumerable<Internship>> ListByUserIdAsync(int userId)
        {
            var request = await _requestRepository.ListByUserIdAsync(userId);
            var internships = request.Select(uc => uc.Internship).ToList();
            return internships;

        }
    }
}
