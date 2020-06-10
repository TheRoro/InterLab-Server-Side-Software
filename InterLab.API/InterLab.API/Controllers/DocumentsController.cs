using AutoMapper;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services;
using InterLab.API.Extensions;
using InterLab.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Controllers
{
    [Route("/api/users/{userId}/documents")]
    public class DocumentsController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;

        public DocumentsController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDocumentResource resource, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var document = _mapper.Map<SaveDocumentResource, Document>(resource);
            var result = await _documentService.SaveAsync(document, userId);

            if (!result.Success)
                return BadRequest(result.Message);

            var documentResource = _mapper.Map<Document, DocumentResource>(result.Resource);
            return Ok(documentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDocumentResource resource)
        {
            var document = _mapper.Map<SaveDocumentResource, Document>(resource);
            var result = await _documentService.UpdateAsync(id, document);

            if (!result.Success)
                return BadRequest(result.Message);
            var documentResource = _mapper.Map<Document, DocumentResource>(result.Resource);
            return Ok(documentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, int userId)
        {
            var result = await _documentService.DeleteAsync(id, userId);

            if (!result.Success)
                return BadRequest(result.Message);
            var documentResource = _mapper.Map<Document, DocumentResource>(result.Resource);
            return Ok(documentResource);
        }

    }
}
