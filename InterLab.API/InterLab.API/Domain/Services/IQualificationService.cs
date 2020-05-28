using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services
{
    public interface IQualificationService
    {
        Task<IEnumerable<Qualification>> ListByUserIdAsync(int userId);
        Task<IEnumerable<Qualification>> ListByCompanyIdAsync(int userId);
        Task<QualificationResponse> GetById(int id);
        Task<QualificationResponse> SaveAsync(Qualification qualification);
        Task<QualificationResponse> UpdateAsync(int id, Qualification qualification);
        Task<QualificationResponse> DeleteAsync(int id);
    }
}
