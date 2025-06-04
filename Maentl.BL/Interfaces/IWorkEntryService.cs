using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Maentl.BL.Interfaces
{
    internal interface IWorkEntryService
    {
        Task<IEnumerable<WorkEntryDto>> GetAllByUserAsync(string userEmail);
        Task<WorkEntryDto> GetByIdAsync(int id);
        Task<WorkEntryDto> CreateAsync(WorkEntryDto dto);
        Task<bool> ApproveAsync(int id, string approverEmail);
        Task<bool> DeleteAsync(int id);
    }
}
