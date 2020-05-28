using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services
{
    public interface IRequestService
    {
        Task<IEnumerable<Request>> ListAsync();
        Task<IEnumerable<Request>> ListByInternshipIdAsync(int internshipId);
        Task<IEnumerable<Request>> ListByUserIdAsync(int userId);
        Task<RequestResponse> GetByIdAsync(int id);
        Task<RequestResponse> SaveAsync(Request request);
        Task<RequestResponse> UpdateAsync(int id, Request request);
        Task<RequestResponse> DeleteAsync(int id);
    }
}
