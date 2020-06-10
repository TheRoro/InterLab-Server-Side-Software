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
        Task<IEnumerable<Document>> ListByUserIdAsync(int userId);
        Task<DocumentResponse> GetById(int id);
        Task<DocumentResponse> SaveAsync(Document document, int userId);
        Task<DocumentResponse> UpdateAsync(int id, Document document);
        Task<DocumentResponse> DeleteAsync(int id, int userId);
    }
}
