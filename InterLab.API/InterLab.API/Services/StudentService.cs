
using InterLab.API.Domain.IServices
using InterLab.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Services
{
    public class StudentService : IStudentService
    {
        public Task<IEnumerable<Student>> ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
