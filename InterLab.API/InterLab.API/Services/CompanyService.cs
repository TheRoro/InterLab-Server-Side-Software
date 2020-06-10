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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserCompanyRepository _userCompanyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUserCompanyRepository userCompanyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _userCompanyRepository = userCompanyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyResponse> GetById(int id)
        {
            var existingCompany = await _companyRepository.FindById(id);

            if (existingCompany == null)
                return new CompanyResponse("Company not found");
            return new CompanyResponse(existingCompany);
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _companyRepository.ListAsync();
        }

        public async Task<CompanyResponse> SaveAsync(Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(company);
            }
            catch (Exception ex)
            {
                return new CompanyResponse($"An error ocurred while saving the company: {ex.Message}");
            }
        }
        public async Task<CompanyResponse> UpdateAsync(int id, Company company)
        {
            var existingCompany = await _companyRepository.FindById(id);
            if (existingCompany == null)
                return new CompanyResponse("Company not found");
            existingCompany.Name = existingCompany.Name;
            existingCompany.Description = existingCompany.Description;

            try
            {
                _companyRepository.Update(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch (Exception ex)
            {
                return new CompanyResponse($"An error ocurred while updating company: {ex.Message}");
            }
        }
        public async Task<CompanyResponse> DeleteAsync(int id)
        {
            var existingCompany = await _companyRepository.FindById(id);
            if (existingCompany == null)
                return new CompanyResponse("Company not found");

            try
            {
                _companyRepository.Remove(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch (Exception ex)
            {
                return new CompanyResponse($"An error ocurred while deleting company: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Company>> ListByUserIdAsync(int userId)
        {
            var userCompanies = await _userCompanyRepository.ListByUserIdAsync(userId);
            var companies = userCompanies.Select(uc => uc.Company).ToList();
            return companies;

        }
    }
}
