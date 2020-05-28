using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IProfileRepository
    {
        //get All
        Task<IEnumerable<Profile>> ListAsync();

        Task<IEnumerable<Profile>> ListByUserId(int userId);

        //getBy Profile
        Task<Profile> FindById(int id);

        //getByStudentId and ProfileId
        Task<Profile> FindByUserIdAndProfileIdAsync(int userId, int profileId);   


        //Add
        Task AddAsync(Profile profile);


        //Delete
        void Update(Profile profile);
        
        //Updated
        void Remove(Profile profile);
    }
}
