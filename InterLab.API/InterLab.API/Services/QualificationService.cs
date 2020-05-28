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
    public class QualificationService : IQualificationService
    {
        private readonly IQualificationRepository _qualificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QualificationService(IQualificationRepository qualificationRepository, IUnitOfWork unitOfWork)
        {
            _qualificationRepository = qualificationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<QualificationResponse> DeleteAsync(int id)
        {
            var existingQualification = await _qualificationRepository.FindById(id);
            if (existingQualification == null)
                return new QualificationResponse("Document not found");

            try
            {
                _qualificationRepository.Remove(existingQualification);
                await _unitOfWork.CompleteAsync();

                return new QualificationResponse(existingQualification);
            }
            catch (Exception ex)
            {
                return new QualificationResponse($"An error ocurred while deleting qualification: {ex.Message}");
            }
        }

        public async Task<QualificationResponse> GetById(int id)
        {
            var existingQualification = await _qualificationRepository.FindById(id);

            if (existingQualification == null)
                return new QualificationResponse("Document not found");
            return new QualificationResponse(existingQualification);
        }

        public async Task<IEnumerable<Qualification>> ListByCompanyIdAsync(int companyId)
        {
            return await _qualificationRepository.ListByCompanyId(companyId);
        }

        public async Task<IEnumerable<Qualification>> ListByUserIdAsync(int userId)
        {
            return await _qualificationRepository.ListByUserId(userId);
        }

        public async  Task<QualificationResponse> SaveAsync(Qualification qualification)
        {

            try
            {
                await _qualificationRepository.AddAsync(qualification);
                await _unitOfWork.CompleteAsync();

                return new QualificationResponse(qualification);
            }
            catch (Exception ex)
            {
                return new QualificationResponse($"An error ocurred while saving the qualification: {ex.Message}");
            }
        }

        public async Task<QualificationResponse> UpdateAsync(int id, Qualification qualification)
        {

            var exstingQualification = await _qualificationRepository.FindById(id);
            if (exstingQualification == null)
                return new QualificationResponse("Qualification not found");
            exstingQualification.Score = qualification.Score;
            exstingQualification.Comment = qualification.Comment;
            exstingQualification.Author = qualification.Author;

            try
            {
                _qualificationRepository.Update(exstingQualification);
                await _unitOfWork.CompleteAsync();

                return new QualificationResponse(exstingQualification);
            }
            catch (Exception ex)
            {
                return new QualificationResponse($"An error ocurred while updating qualification: {ex.Message}");
            }
        }
    }
}
