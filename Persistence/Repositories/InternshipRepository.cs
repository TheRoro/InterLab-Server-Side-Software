using InterLab.API.Domain.Models;
using InterLab.API.Domain.Repositories;
using InterLab.API.Domain.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Persistence.Repositories
{
    public class InternshipRepository : BaseRepository, IInternshipRepository
    {
        public InternshipRepository(AppDbContext context) : base(context) { }

        public async Task<Internship> FindByIdAsync(int id)
        {
            return await _context.Internships.FindAsync(id);
        }
        public async Task<Internship> FindByCompanyIdAndIntershipIdAsynd(int companyId, int id)
        {
            return await _context.Internships.FindAsync(id, companyId);
        }

        public async Task<IEnumerable<Internship>> ListAsync()
        {
            return await _context.Internships.ToListAsync();
        }
        public async Task<IEnumerable<Internship>> ListByCompanyIdAsync(int companyId) =>
             await _context.Internships
            .Where(p => p.CompanyId == companyId)
            .Include(p => p.Company)
            .ToListAsync();

        public async Task AddAsync(Internship internship)
        {
            await _context.Internships.AddAsync(internship);
        }
        public void Update(Internship internship)
        {
            _context.Internships.Update(internship);
        }

        public void Remove(Internship internship)
        {
            _context.Internships.Remove(internship);
        }
    }
}
