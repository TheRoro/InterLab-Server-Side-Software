using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services
{
    public interface IUserCompanyService
    {
        Task<IEnumerable<UserCompany>> ListAsync();
        Task<IEnumerable<UserCompany>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserCompany>> ListByCompanyIdAsync(int companyId);
        Task<UserCompanyResponse> AssignUserCompanyAsync(int userId, int companyId);
        Task<UserCompanyResponse> UnassignUserCompanyAsync(int userId, int companyId);

    }
}
