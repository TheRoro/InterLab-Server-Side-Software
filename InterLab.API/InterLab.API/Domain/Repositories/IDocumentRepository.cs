using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IDocumentRepository
    {
        //get All
        Task<IEnumerable<Document>> ListAsync();
        //get By UserId
        //Task<IEnumerable<Document>> ListByUserIdAsync(int userId);
        //Add
        Task AddAsync(Document document);
        //Delete
        void Remove(Document document);
        //Update
        void Update(Document document);

    }
}
