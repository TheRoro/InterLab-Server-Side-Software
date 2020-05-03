using InterLab.API.Domain.IRepositories;
using InterLab.API.Domain.IServices;
using InterLab.API.Domain.Models;
using InterLab.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Services
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await _studentRepository.ListAsync();
        }
    }
}
