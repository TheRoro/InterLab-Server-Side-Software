using InterLab.API.Controllers;
using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.IRepositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> ListAsync();
        Task AddAsync(Student student);
        Task<Student> FindByIdAsync(int id);
        void Update(Student student);
        void Remove(Student student);
    }
}
