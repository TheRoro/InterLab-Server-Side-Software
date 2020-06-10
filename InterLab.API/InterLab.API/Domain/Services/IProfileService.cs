using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services
{
    public interface IProfileService
    {
        //get All
        Task<IEnumerable<Profile>> ListAsync();

        Task<IEnumerable<Profile>> ListByUserId(int userId);


        //getByUserId and ProfileId
        Task<Profile> GetByIdAndUsertId(int id, int userId);  


        //gett by FindId
        Task<ProfileResponse> GetByIdAsync(int id);

        Task<ProfileResponse> SaveAsync(Profile profile, int userId); 
        Task<ProfileResponse> UpdateAsync(int id, Profile profile);
        Task<ProfileResponse> DeleteAsync(int id);
    }
}
