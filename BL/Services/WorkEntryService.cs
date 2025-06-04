using BL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class WorkEntryService : IWorkEntryService
    {
        public Task<IEnumerable<WorkEntryDto>> GetAllByUserAsync(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<WorkEntryDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkEntryDto> CreateAsync(WorkEntryDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ApproveAsync(int id, string approverEmail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(WorkEntryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
