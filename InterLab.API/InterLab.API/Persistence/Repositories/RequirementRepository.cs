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
    public class RequirementRepository : BaseRepository, IRequirementRepository
    {
        public RequirementRepository(AppDbContext context) : base(context) { }

        public async Task<Requirement> FindByIdAsync(int id)
        {
            return await _context.Requirements.FindAsync(id);
        }

        public async Task<IEnumerable<Requirement>> ListAsync()
        {
            return await _context.Requirements.ToListAsync();
        }
        public async Task<IEnumerable<Requirement>> ListByInternshipIdAsync(int internshipId) =>
            await _context.Requirements
            .Where(r => r.InternshipId == internshipId)
            .Include(r => r.Internship)
            .ToListAsync();

        public async Task AddAsync(Requirement requirement)
        {
            await _context.Requirements.AddAsync(requirement);
        }
        public void Update(Requirement requirement)
        {
            _context.Requirements.Update(requirement);
        }
        public void Remove(Requirement requirement)
        {
            _context.Requirements.Remove(requirement);
        }
    }
}
