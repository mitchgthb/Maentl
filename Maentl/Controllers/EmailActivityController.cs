using DTO;
using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BL.Processors;
using Microsoft.AspNetCore.Authorization;

namespace Maentl.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailActivityController : ControllerBase
    {
        private readonly IEmailActivityService _emailActivityService;
        private readonly IActivityProcessor<EmailActivityDto> _processor;

        public EmailActivityController(
            IEmailActivityService emailActivityService,
            IActivityProcessor<EmailActivityDto> processor)
        {
            _emailActivityService = emailActivityService;
            _processor = processor;
        }

        [HttpGet("user/{userEmail}")]
        public async Task<IActionResult> GetForUser(string userEmail)
        {
            var emails = await _emailActivityService.GetForUserAsync(userEmail);
            return Ok(emails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var activity = await _emailActivityService.GetByIdAsync(id);
            return activity == null ? NotFound() : Ok(activity);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] EmailActivityDto dto)
        {
            var success = await _emailActivityService.SaveAsync(dto);
            return success ? Ok() : BadRequest("Failed to save email activity.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _emailActivityService.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }

        [Authorize]
        [HttpPost("process")]
        public async Task<IActionResult> ProcessEmail([FromBody] EmailActivityDto email)
        {
            await _processor.ProcessAsync(email);
            return Ok("Processed.");
        }
    }
}
