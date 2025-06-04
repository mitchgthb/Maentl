using BL.DTOAdapters;
using BL.Interfaces;
using DTO;
using Maentl.SQL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly MaentlDbContext _db;

        public CalendarService(MaentlDbContext db)
        {
            _db = db;
        }

        public async Task<List<CalendarEventDto>> GetEventsForUserAsync(string userEmail)
        {
            var events = await _db.CalendarEvents
                .Where(e => e.UserEmail == userEmail)
                .ToListAsync();

            return events.Select(CalendarEventMapper.ToDto).ToList();
        }

        public async Task<CalendarEventDto> GetEventByIdAsync(Guid id)
        {
            var entity = await _db.CalendarEvents.FindAsync(id);
            return CalendarEventMapper.ToDto(entity);
        }

        public async Task<bool> SaveEventAsync(CalendarEventDto dto)
        {
            var entity = CalendarEventMapper.ToEntity(dto);
            var exists = await _db.CalendarEvents.AnyAsync(e => e.Id == entity.Id);

            if (exists)
                _db.CalendarEvents.Update(entity);
            else
                await _db.CalendarEvents.AddAsync(entity);

            return (await _db.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteEventAsync(Guid id)
        {
            var entity = await _db.CalendarEvents.FindAsync(id);
            if (entity == null) return false;

            _db.CalendarEvents.Remove(entity);
            return (await _db.SaveChangesAsync()) > 0;
        }

        public async Task<List<CalendarEventDto>> GetEventsForUserInRangeAsync(string userEmail, DateTime start, DateTime end)
        {
            var events = await _db.CalendarEvents
                .Where(e => e.UserEmail == userEmail && e.StartTime >= start && e.EndTime <= end)
                .ToListAsync();

            return events.Select(CalendarEventMapper.ToDto).ToList();
        }

    }
}
