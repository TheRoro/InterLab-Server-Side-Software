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

        //getBy Profile
        Task<Profile> FindById(int id);

        ////get By StudentId
        //Task<IEnumerable<Profile>> ListByStudentId(int studentId);

        ////get By WorkerId
        //Task<IEnumerable<Profile>> ListByWorkerId(int workerId);


        //getByStudentId and ProfileId
        Task<Profile> FindByStudentIdAndProfileIdAsync(int studentId, int profileId); 

        //getByWorkerId and ProfileId 
        Task<Profile> FindByWorkerIdAndProfileIdAsync(int workerId, int profileId); 


        //Add
        Task AddAsync(Profile profile);


        //Delete
        void Update(Profile profile);
        
        //Updated
        void Remove(Profile profile);
    }
}
