using AutoMapper;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services;
using InterLab.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Controllers
{
    [Route("/api/users/{userId}/documents")]
    public class UserDocumentsController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;

        public UserDocumentsController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DocumentResource>> GetAllByUserId(int userId)
        {
            var documents = await _documentService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Document>, IEnumerable<DocumentResource>>(documents);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentByIdAsync(int id)
        {
            var result = await _documentService.GetById(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var documentResource = _mapper.Map<Document, DocumentResource>(result.Resource);
            return Ok(documentResource);

        }



    }
}