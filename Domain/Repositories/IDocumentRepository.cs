using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    public interface IDocumentRepository
    {
        //get By UserId
        Task<IEnumerable<Document>> ListByUserId(int userId);
        //getlBy DocumentId
        Task<Document> FindById(int id);
        //getByUserd and DocumentId
        Task<Document> FindByUserIdAndDocumentIdAsync(int userId, int Id);
        //Add
        Task AddAsync(Document document);
        //Delete
        void Remove(Document document);
        //Update
        void Update(Document document);

    }
}
