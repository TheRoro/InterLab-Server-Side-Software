using InterLab.API.Domain.Models;
using InterLab.API.Persistence.Repositories;
using InterLab.API.Domain.Persistence.Contexts;
using InterLab.API.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InterLab.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
