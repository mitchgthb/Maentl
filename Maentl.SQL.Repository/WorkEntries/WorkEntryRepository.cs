using Maentl.SQL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maentl.SQL.Repository.WorkEntries
{
    public class WorkEntryRepository : Repository<WorkEntry, int>, IWorkEntryRepository
    {
        public WorkEntryRepository(MaentlDbContext context) : base(context) { }

        public async Task<IEnumerable<WorkEntry>> GetByUserAsync(string userEmail)
        {
            return await _context.WorkEntries
                .Where(w => w.UserEmail.ToLower() == userEmail.ToLower())
                .ToListAsync();
        }

        public async Task<WorkEntry> GetWithProjectAsync(int id)
        {
            return await _context.WorkEntries
                .Include(w => w.RelatedProject)
                .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
