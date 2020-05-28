using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IRequestRepository
    {
        Task<IEnumerable<Request>> ListAsync();
        Task AddAsync(Request request);
        Task<Request> FindByIdAsync(int id);
        Task<IEnumerable<Request>> ListByInternshipIdAsync(int internshipId);
        Task<IEnumerable<Request>> ListByUserIdAsync(int userId);
        void Update(Request request);
        void Remove(Request request);
    }
}
