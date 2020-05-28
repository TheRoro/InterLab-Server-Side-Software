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
    public class QualificationRepository : BaseRepository, IQualificationRepository
    {
        public QualificationRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Qualification qualification)
        {
            await _context.Qualifications.AddAsync(qualification);
        }

        public async Task<Qualification> FindById(int id)
        {
            return await _context.Qualifications.FindAsync(id);
        }

        public async Task<IEnumerable<Qualification>> ListByCompanyId(int companyId) =>
            await _context.Qualifications
            .Where(q => q.CompanyId == companyId)
            .Where(q => q.Author == "user")
            .Include(q => q.User)
            .ToListAsync();

        public async Task<IEnumerable<Qualification>> ListByUserId(int userId) =>
            await _context.Qualifications
            .Where(q => q.UserId == userId)
            .Where(q => q.Author == "company")
            .Include(q => q.User)
            .ToListAsync();

        public void Remove(Qualification qualification)
        {
            _context.Qualifications.Remove(qualification);
        }

        public void Update(Qualification qualification)
        {
            _context.Qualifications.Update(qualification);
        }
    }
}
