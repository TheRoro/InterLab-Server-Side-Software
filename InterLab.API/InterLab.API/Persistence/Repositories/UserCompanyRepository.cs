using InterLab.API.Domain.Models;
using InterLab.API.Domain.Persistence.Contexts;
using InterLab.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Persistence.Repositories
{
    public class UserCompanyRepository : BaseRepository, IUserCompanyRepository
    {
        public UserCompanyRepository(AppDbContext context) : base(context) { }

        public async Task<UserCompany> FindByUserIdAndCompanyId(int userId, int companyId)
        {
            return await _context.UserCompanies.FindAsync(userId, companyId);
        }

        public async Task<IEnumerable<UserCompany>> ListAsync()
        {
            return await _context.UserCompanies
            .Include(uc => uc.User)
            .Include(uc => uc.Company)
            .ToListAsync();
        }
        public async Task<IEnumerable<UserCompany>> ListByCompanyIdAsync(int companyId)
        {
            return await _context.UserCompanies
            .Where(uc => uc.CompanyId == companyId)
            .Include(uc => uc.User)
            .Include(uc => uc.Company)
            .ToListAsync();
        }
        public async Task<IEnumerable<UserCompany>> ListByUserIdAsync(int userId)
        {
            return await _context.UserCompanies
            .Where(uc => uc.UserId == userId)
            .Include(uc => uc.User)
            .Include(uc => uc.Company)
            .ToListAsync();
        }

        public async Task AddAsync(UserCompany userCompany)
        {
            await _context.UserCompanies.AddAsync(userCompany);
        }
        public void Remove(UserCompany userCompany)
        {
            _context.UserCompanies.Remove(userCompany);
        }

        public async Task AssignUserCompany(int userId, int companyId)
        {
            UserCompany userCompany = await FindByUserIdAndCompanyId(userId, companyId);
            if (userCompany == null)
            {
                userCompany = new UserCompany { UserId = userId, CompanyId = companyId };
                await AddAsync(userCompany);
            }
        }
        public async void UnassignUserCompany(int userId, int companyId)
        {
            UserCompany userCompany = await FindByUserIdAndCompanyId(userId, companyId);
            if (userCompany != null)
            {
                Remove(userCompany);
            }
        }
    }
}
