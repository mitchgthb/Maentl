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
    public class EmailActivityService : IEmailActivityService
    {
        private readonly MaentlDbContext _db;

        public EmailActivityService(MaentlDbContext db)
        {
            _db = db;
        }

        public async Task<List<EmailActivityDto>> GetForUserAsync(string userEmail)
        {
            var results = await _db.EmailActivities
                .Where(x => x.UserEmail.ToLower() == userEmail.ToLower())
                .ToListAsync();

            return results.Select(EmailActivityMapper.ToDto).ToList();
        }

        public async Task<EmailActivityDto?> GetByIdAsync(Guid id)
        {
            var entity = await _db.EmailActivities.FindAsync(id);
            return entity == null ? null : EmailActivityMapper.ToDto(entity);
        }

        public async Task<bool> SaveAsync(EmailActivityDto dto)
        {
            var entity = EmailActivityMapper.ToEntity(dto);
            var exists = await _db.EmailActivities.AnyAsync(x => x.Id == entity.Id);

            if (exists)
            {
                entity.ModifiedAt = DateTime.UtcNow;
                _db.EmailActivities.Update(entity);
            }
            else
            {
                entity.CreatedAt = DateTime.UtcNow;
                _db.EmailActivities.Add(entity);
            }

            return (await _db.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _db.EmailActivities.FindAsync(id);
            if (entity == null) return false;

            _db.EmailActivities.Remove(entity);
            return (await _db.SaveChangesAsync()) > 0;
        }
    }
}
