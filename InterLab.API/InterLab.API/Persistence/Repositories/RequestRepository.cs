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

        public async Task<Request> FindByIdAsync(int id)
        {
            return await _context.Requests.FindAsync(id);
        }
        public async Task<Request> FindByUserIdAndInternshipId(int userId, int internshipId)
        {
            return await _context.Requests.FindAsync(userId, internshipId);
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

        public async Task<IEnumerable<Request>> ListByUserIdAsync(int userId)
        {
            return await _context.Requests
            .Where(uc => uc.UserId == userId)
            .Include(uc => uc.User)
            .Include(uc => uc.Internship)
            .ToListAsync();
        }

        public async Task AddAsync(Request request)
        {
            await _context.Requests.AddAsync(request);
        }
        public void Update(Request request)
        {
            _context.Requests.Update(request);
        }
        public void Remove(Request request)
        {
            _context.Requests.Remove(request);
        }

        public async Task AssignUserInternship(int userId, int internshipId)
        {
            Request request = await FindByUserIdAndInternshipId(userId, internshipId);
            if (request == null)
            {
                request = new Request { UserId = userId, InternshipId = internshipId };
                await AddAsync(request);
            }
        }
    }
}
