using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IRequestRepository
    {
        Task<IEnumerable<Request>> ListByUserIdAsync(int userId);
        Task<Request> FindByIdAsync(int id);
        Task<Request> FindByInternshipIdAndRequestIdAsync(int internshipId, int id);
        Task<Request> FindByUserIdAndRequestIdAsync(int userId, int id);
        Task<IEnumerable<Request>> ListAsync();
        Task AddAsync(Request request);
        Task<IEnumerable<Request>> ListByInternshipIdAsync(int internshipId);

        void Update(Request request);
        void Remove(Request request);

    }
}
