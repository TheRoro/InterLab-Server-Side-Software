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
        //getlBy Document
        Task<Document> FindById(int id);
        //getByStudentId and DocumentId
        //Task<Document> FindByStudentIdAndDocumentIdAsynd(int studentId, int documentId);
        //get By StudentId
        //Task<IEnumerable<Document>> ListByStudentId(int studentId);
        //Add
        Task AddAsync(Document document);
        //Delete
        void Remove(Document document);
        //Update
        void Update(Document document);

    }
}
