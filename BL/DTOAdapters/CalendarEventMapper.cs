using DTO;
using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOAdapters
{
    public static class CalendarEventMapper
    {
        public static CalendarEventDto ToDto(CalendarEvent entity)
        {
            if (entity == null) return null;

            return new CalendarEventDto
            {
                Id = entity.Id,
                Subject = entity.Subject,
                Location = entity.Location,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                OrganizerEmail = entity.OrganizerEmail,
                AttendeeEmail = entity.AttendeeEmail,
                IsPrivate = entity.IsPrivate,
                SourceSystem = entity.SourceSystem,
                UserEmail = entity.UserEmail
            };
        }

        public static CalendarEvent ToEntity(CalendarEventDto dto)
        {
            if (dto == null) return null;

            return new CalendarEvent
            {
                Id = dto.Id,
                Subject = dto.Subject,
                Location = dto.Location,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                OrganizerEmail = dto.OrganizerEmail,
                AttendeeEmail = dto.AttendeeEmail,
                IsPrivate = dto.IsPrivate,
                SourceSystem = dto.SourceSystem,
                UserEmail = dto.UserEmail
            };
        }
    }
}
