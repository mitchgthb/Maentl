using BL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maentl.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpGet("user/{userEmail}")]
        public async Task<IActionResult> GetForUser(string userEmail)
        {
            var events = await _calendarService.GetEventsForUserAsync(userEmail);
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var calendarEvent = await _calendarService.GetEventByIdAsync(id);
            return calendarEvent == null ? NotFound() : Ok(calendarEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] CalendarEventDto dto)
        {
            var success = await _calendarService.SaveEventAsync(dto);
            return success ? Ok() : BadRequest("Failed to save calendar event.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _calendarService.DeleteEventAsync(id);
            return success ? Ok() : NotFound();
        }

        [HttpGet("range")]
        public async Task<IActionResult> GetForUserInRange(
            [FromQuery] string userEmail,
            [FromQuery] DateTime start,
            [FromQuery] DateTime end)
        {
            var events = await _calendarService.GetEventsForUserInRangeAsync(userEmail, start, end);
            return Ok(events);
        }


    }
}
