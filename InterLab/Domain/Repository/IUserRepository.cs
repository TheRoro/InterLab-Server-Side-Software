using InterLab.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
    }
}
