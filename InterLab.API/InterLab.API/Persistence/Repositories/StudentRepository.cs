using InterLab.API.Domain.Models;
using InterLab.API.Persistence.Repositories;
using InterLab.API.Persistence.Contexts;
using InterLab.API.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InterLab.API.Persistence.Repositories
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task<Student> FindByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
        }

        public void Remove(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}
