using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Validation
{
    public static class CalendarEventValidator
    {
        public static bool IsValid(CalendarEvent calendarEvent, out List<string> errors)
        {
            errors = new();

            if (string.IsNullOrWhiteSpace(calendarEvent.Subject))
                errors.Add("Subject is required.");

            if (calendarEvent.StartTime >= calendarEvent.EndTime)
                errors.Add("Start time must be before end time.");

            if (string.IsNullOrWhiteSpace(calendarEvent.UserEmail))
                errors.Add("User email is required.");

            return !errors.Any();
        }
    }
}
