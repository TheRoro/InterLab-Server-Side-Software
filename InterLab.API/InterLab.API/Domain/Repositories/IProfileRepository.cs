using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterLab.API.Domain.Models;

namespace InterLab.API.Domain.Repositories
{
    public interface IProfileRepository
    {
        //Get All
        Task<IEnumerable<Profile>> ListAsync();

        //Post
        Task AddAsync (Profile profile);

        //GetFindId
        Task<IEnumerable<Profile>> FindByIdAsync(Profile profile);

        //Delete
        Task Remove(Profile profile);

        //Put
        Task Update(Profile profile);
    }
}
