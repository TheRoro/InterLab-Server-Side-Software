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

        ////get By StudentId
        //Task<IEnumerable<Profile>> ListByStudentId(int studentId);

        ////get By WorkerId
        //Task<IEnumerable<Profile>> ListByWorkerId(int workerId); 


        //getByStudentId and ProfileId
        Task<Profile> GetByIdAndStudentId(int id, int studentId);


        //getByWorkerId and ProfileId
        Task<Profile> GetByIdAndWorkerId(int id, int workerId);


        //gett by FindId
        Task<ProfileResponse> GetByIdAsync(int id);

        Task<ProfileResponse> SaveAsync(Profile profile); 
        Task<ProfileResponse> UpdateAsync(int id, Profile profile);
        Task<ProfileResponse> DeleteAsync(int id);
    }
}
