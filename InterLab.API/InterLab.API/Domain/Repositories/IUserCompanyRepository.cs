using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IUserCompanyRepository
    {
        Task<UserCompany> FindByUserIdAndCompanyId(int userId, int companyId);

        Task<IEnumerable<UserCompany>> ListAsync();
        Task<IEnumerable<UserCompany>> ListByCompanyIdAsync(int companyId);

        Task<IEnumerable<UserCompany>> ListByUserIdAsync(int userId);

        Task AddAsync(UserCompany userCompany);
        void Remove(UserCompany userCompany);

        Task AssignUserCompany(int userId, int companyId);
        void UnassignUserCompany(int userId, int companyId);

    }
}
