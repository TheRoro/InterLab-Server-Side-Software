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

        ////get By UserId
        //Task<IEnumerable<Profile>> ListUsertId(int userId);


        //getByUserId and ProfileId
        Task<Profile> GetByIdAndUserId(int id, int studentId); 

        //gett by FindId
        Task<ProfileResponse> GetByIdAsync(int id);

        Task<ProfileResponse> SaveAsync(Profile profile); 
        Task<ProfileResponse> UpdateAsync(int id, Profile profile);
        Task<ProfileResponse> DeleteAsync(int id);
    }
}
