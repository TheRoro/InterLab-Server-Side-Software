using InterLab.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.IServices.InterfaceServices
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> ListAsync();
    }
}
