using BL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maentl.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string userEmail)
        {
            var docs = await _documentService.GetAllForUserAsync(userEmail);
            return Ok(docs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var doc = await _documentService.GetByIdAsync(id);
            return doc == null ? NotFound() : Ok(doc);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DocumentDto dto)
        {
            var success = await _documentService.SaveAsync(dto);
            return success ? Ok() : BadRequest("Could not save document.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _documentService.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }
    }
}
