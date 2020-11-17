using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IRequestRepository
    {
        Task<Request> FindByIdAsync(int id);
        Task<Request> FindByInternshipIdAndRequestIdAsync(int internshipId, int id);
        Task<Request> FindByUserIdAndRequestIdAsync(int userId, int id);
        Task<Request> FindByUserIdAndInternshipId(int userId, int internshipId);

        Task<IEnumerable<Request>> ListAsync();
        Task<IEnumerable<Request>> ListByUserIdAsync(int userId);
        Task<IEnumerable<Request>> ListByInternshipIdAsync(int internshipId);

        Task AddAsync(Request request);
        void Update(Request request);
        void Remove(Request request);

        Task AssignUserInternship(int userId, int internshipId);

    }
}
