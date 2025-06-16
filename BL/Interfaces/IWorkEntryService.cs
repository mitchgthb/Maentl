using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Enums;
using Maentl.SQL.Model;

namespace BL.Interfaces
{
    public interface IWorkEntryService
    {
        Task<IEnumerable<WorkEntryDto>> GetAllByUserAsync(string userEmail);
        Task<WorkEntryDto> GetByIdAsync(int id);
        Task<WorkEntryDto> CreateAsync(WorkEntryDto dto);
        Task<WorkEntry> CreateOrUpdateWorkEntryAsync(
           string userEmail,
           WorkSource sourceType,
           string sourceReference,
           DateTime startTime,
           DateTime endTime,
           double effortHours,
           WorkTypeEnum workType,
           int complexityScore,
           EffortMethod effortMethod = EffortMethod.Automatic,
           string notes = null,
           int? projectId = null);

        Task<bool> SaveAsync(WorkEntryDto dto);
        Task<bool> ApproveAsync(int id, string approverEmail);
        Task<bool> DeleteAsync(int id);
    }
}
