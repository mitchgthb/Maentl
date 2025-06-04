using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ICalendarService
    {
        Task<List<CalendarEventDto>> GetEventsForUserAsync(string userEmail);
        Task<CalendarEventDto> GetEventByIdAsync(Guid id);
        Task<bool> SaveEventAsync(CalendarEventDto calendarEvent);
        Task<bool> DeleteEventAsync(Guid id);
        Task<List<CalendarEventDto>> GetEventsForUserInRangeAsync(string userEmail, DateTime start, DateTime end);
    }
}
