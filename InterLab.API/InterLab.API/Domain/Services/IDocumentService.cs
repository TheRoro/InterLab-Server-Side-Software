using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services
{
    public interface IDocumentService
    {
        Task<IEnumerable<Document>> ListAsync();
        Task<IEnumerable<Document>> ListByStudentId();
        Task<Document> GetByIdAndStudentId(int id, int studentId);
        Task<DocumentResponse> SaveAsync(Document document);
        Task<DocumentResponse> UpdateAsync(int id, Document document);
        Task<DocumentResponse> DeleteAsync(int id);
    }
}
