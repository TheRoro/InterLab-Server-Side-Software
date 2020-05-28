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
    public class RequestRepository : BaseRepository, IRequestRepository
    {
        public RequestRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Request request)
        {
            await _context.Requests.AddAsync(request);
        }

        public async Task<Request> FindByIdAsync(int id)
        {
            return await _context.Requests.FindAsync(id);
        }

        public async Task<Request> FindByInternshipIdAndRequestIdAsync(int internshipId, int id)
        {
            return await _context.Requests.FindAsync(id, internshipId);
        }

        public async Task<Request> FindByUserIdAndRequestIdAsync(int userId, int id)
        {
            return await _context.Requests.FindAsync(id, userId);
        }

        public async Task<IEnumerable<Request>> ListAsync()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<IEnumerable<Request>> ListByInternshipIdAsync(int internshipId) =>
            await _context.Requests
            .Where(r => r.InternshipId == internshipId)
            .Include(r => r.Internship)
            .ToListAsync();

        public async Task<IEnumerable<Request>> ListByUserIdAsync(int userId) =>
            await _context.Requests
            .Where(r => r.UserId == userId)
            .Include(r => r.User)
            .ToListAsync();

        public void Remove(Request request)
        {
            _context.Requests.Remove(request);
        }

        public void Update(Request request)
        {
            _context.Requests.Update(request);
        }
    }
}
