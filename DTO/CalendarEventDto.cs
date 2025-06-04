using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CalendarEventDto
    {
        public Guid Id { get; set; }

        public string Subject { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string OrganizerEmail { get; set; }

        public string AttendeeEmail { get; set; }

        public bool IsPrivate { get; set; }

        public SourceSystem SourceSystem { get; set; }

        public string UserEmail { get; set; }

        public double DurationMinutes => (EndTime - StartTime).TotalMinutes;
    }
}
