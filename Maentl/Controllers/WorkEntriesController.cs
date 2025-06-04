using BL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maentl.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkEntriesController : ControllerBase
    {
        private readonly IWorkEntryService _workEntryService;

        public WorkEntriesController(IWorkEntryService workEntryService)
        {
            _workEntryService = workEntryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string userEmail)
        {
            var entries = await _workEntryService.GetAllByUserAsync(userEmail);
            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entry = await _workEntryService.GetByIdAsync(id);
            return entry == null ? NotFound() : Ok(entry);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkEntryDto dto)
        {
            var success = await _workEntryService.SaveAsync(dto);
            return success ? Ok() : BadRequest("Unable to save work entry.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _workEntryService.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }

        [HttpPost("{id}/approve")]
        public async Task<IActionResult> Approve(int id, [FromQuery] string approverEmail)
        {
            var success = await _workEntryService.ApproveAsync(id, approverEmail);
            return success ? Ok() : NotFound();
        }
    }
}
