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
    public class ProfileRepository : BaseRepository, IProfileRepository
    {
        public ProfileRepository(AppDbContext context) : base(context){ }

        public async Task AddAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
        }

        public async Task<Profile> FindById(int id)
        {
            return await _context.Profiles.FindAsync(id);
        }

        public async Task<Profile> FindByStudentIdAndProfileIdAsync(int studentId, int profileId)
        {
            return await _context.Profiles.FindAsync(studentId, profileId);
        }

        public async Task<Profile> FindByWorkerIdAndProfileIdAsync(int workerId, int profileId)
        {
            return await _context.Profiles.FindAsync(workerId, profileId);
        }

        public async Task<IEnumerable<Profile>> ListAsync()
        {
            return await _context.Profiles.ToListAsync();
        }

        //public async Task<IEnumerable<Profile>> ListByStudentId(int studentId) =>

        //    await _context.Profiles
        //    .Where(p => p.StudentId == studentId)
        //    .Include(p => p.Student)
        //    .ToListAsync();
   

        //public async Task<IEnumerable<Profile>> ListByWorkerId(int workerId) =>
        
        //    await _context.Profiles
        //    .Where(p => p.WorkerId == workerId)
        //    .Include(p => p.Worker)
        //    .ToListAsync();
        
       

        public void Remove(Profile profile)
        {
            _context.Profiles.Remove(profile);
        }

        public void Update(Profile profile)
        {
            _context.Profiles.Update(profile);
        }
    }
}
