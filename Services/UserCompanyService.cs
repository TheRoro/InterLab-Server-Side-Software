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
    public class UserCompanyService : IUserCompanyService
    {
        private readonly IUserCompanyRepository _userCompanyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserCompanyService(IUserCompanyRepository userCompanyRepository, IUnitOfWork unitOfWork)
        {
            _userCompanyRepository = userCompanyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserCompany>> ListAsync()
        {
            return await _userCompanyRepository.ListAsync();
        }
        public async Task<IEnumerable<UserCompany>> ListByCompanyIdAsync(int companyId)
        {
            return await _userCompanyRepository.ListByCompanyIdAsync(companyId);
        }
        public async Task<IEnumerable<UserCompany>> ListByUserIdAsync(int userId)
        {
            return await _userCompanyRepository.ListByUserIdAsync(userId);
        }
        public async Task<UserCompanyResponse> AssignUserCompanyAsync(int userId, int companyId)
        {
            try
            {

                await _userCompanyRepository.AssignUserCompany(userId, companyId);
                await _unitOfWork.CompleteAsync();
                UserCompany userCompany = await _userCompanyRepository.FindByUserIdAndCompanyId(userId, companyId);
                return new UserCompanyResponse(userCompany);
            }
            catch (Exception ex)
            {
                return new UserCompanyResponse($"An error ocurred while assigning Company to User: {ex.Message}");
            }

        }
        public async Task<UserCompanyResponse> UnassignUserCompanyAsync(int userId, int companyId)
        {
            try
            {
                UserCompany userCompany = await _userCompanyRepository.FindByUserIdAndCompanyId(userId, companyId);
                _userCompanyRepository.Remove(userCompany);
                await _unitOfWork.CompleteAsync();
                return new UserCompanyResponse(userCompany);
            }
            catch (Exception ex)
            {
                return new UserCompanyResponse($"An error ocurred while unassigning Company to User: {ex.Message}");
            }
        }
    }
}
