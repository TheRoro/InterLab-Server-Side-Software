using InterLab.API.Domain.Models;
using InterLab.API.Domain.Persistence.Contexts;
using InterLab.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Persistence.Repositories
{
    public class DocumentRepository : BaseRepository, IDocumentRepository
    {
        public DocumentRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Document document)
        {
            await _context.Documents.AddAsync(document); 
        }

        public async Task<Document> FindById(int id)
        {
            return await _context.Documents.FindAsync(id);
        }

       /* public async Task<Document> FindByStudentIdAndDocumentIdAsynd(int studentId, int documentId)
        {
            return await _context.Documents.FindAsync(studentId, documentId);
        }*/

        public async Task<IEnumerable<Document>> ListAsync()
        {
            return await _context.Documents.ToListAsync();
        }

        //public async Task<IEnumerable<Document>> ListByStudentId(int studentId) =>
        //    await _context.Documents
        //    .Where(p => p.StudentId == studentId)
        //    .Include(p => p.Student)
        //    .ToListAsync();


        public void Remove(Document document)
        {
            _context.Documents.Remove(document);
        }

        public void Update(Document document)
        {
            _context.Documents.Update(document);
        }
    }
}
