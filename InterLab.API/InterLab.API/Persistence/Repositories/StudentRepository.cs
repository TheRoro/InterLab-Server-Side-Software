using InterLab.API.Domain.InterfaceRepository;
using InterLab.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Persistence.Repositories
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public Task<IEnumerable<Student>> ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
