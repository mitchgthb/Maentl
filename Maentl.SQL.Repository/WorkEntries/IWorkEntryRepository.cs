using Maentl.SQL.Model;
using Maentl.SQL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maentl.SQL.Repository.WorkEntries
{
    public interface IWorkEntryRepository : IRepository<WorkEntry, int>
    {
        Task<IEnumerable<WorkEntry>> GetByUserAsync(string userEmail);
        Task<WorkEntry> GetWithProjectAsync(int id);
    }
}
