using InterLab.API.Controllers;
using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<User> FindByIdAsync(int id);

        Task<IEnumerable<User>> ListAsync();

        Task AddAsync(User user);
        void Update(User user);
        void Remove(User user);
    }
}
