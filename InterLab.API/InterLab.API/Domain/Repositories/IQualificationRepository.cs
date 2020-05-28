using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IQualificationRepository
    {
        //get By UserId
        Task<IEnumerable<Qualification>> ListByUserId(int userId);
        //get By CompanyId
        Task<IEnumerable<Qualification>> ListByCompanyId(int companyId);
        //getlBy DocumentId
        Task<Qualification> FindById(int id);
        //Add
        Task AddAsync(Qualification document);
        //Delete
        void Remove(Qualification document);
        //Update
        void Update(Qualification document);
    }
}
