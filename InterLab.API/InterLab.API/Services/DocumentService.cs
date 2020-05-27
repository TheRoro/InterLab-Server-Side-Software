using System;
using InterLab.API.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterLab.API.Domain.Repositories;
using InterLab.API.Domain.Services.Communication;
using InterLab.API.Domain.Models;

namespace InterLab.API.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DocumentService(IDocumentRepository documentRepository, IUnitOfWork unitOfWork)
        {
            _documentRepository = documentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DocumentResponse> DeleteAsync(int id)
        {
            var existingDocument = await _documentRepository.FindById(id);
            if (existingDocument == null)
                return new DocumentResponse("Document not found");

            try
            {
                _documentRepository.Remove(existingDocument);
                await _unitOfWork.CompleteAsync();

                return new DocumentResponse(existingDocument);
            }
            catch (Exception ex)
            {
                return new DocumentResponse($"An error ocurred while deleting document: {ex.Message}");
            }
        }

        public async Task<DocumentResponse> GetByIdAndUserId(int id, int studentId)
        {
            var existingDocument = await _documentRepository.FindByUserIdAndDocumentIdAsynd(id, studentId);

            if (existingDocument == null)
                return new DocumentResponse("Document not found");
            return new DocumentResponse(existingDocument);
            
        }


        public async Task<IEnumerable<Document>> ListByUserId(int userId)
        {
            return await _documentRepository.ListByUserId(userId);
        }

        public async Task<DocumentResponse> SaveAsync(Document document)
        {
            try
            {
                await _documentRepository.AddAsync(document);
                await _unitOfWork.CompleteAsync();

                return new DocumentResponse(document);
            }
            catch (Exception ex)
            {
                return new DocumentResponse($"An error ocurred while saving the document: {ex.Message}");
            }
        }

        public async Task<DocumentResponse> UpdateAsync(int id, Document document)
        {
            var existingDocument = await _documentRepository.FindById(id);
            if (existingDocument == null)
                return new DocumentResponse("Document not found");
            existingDocument.Name = document.Name;
            existingDocument.Description = document.Description;

            try
            {
                _documentRepository.Update(existingDocument);
                await _unitOfWork.CompleteAsync();

                return new DocumentResponse(existingDocument);
            }
            catch (Exception ex)
            {
                return new DocumentResponse($"An error ocurred while updating document: {ex.Message}");
            }
        }
    }
}
