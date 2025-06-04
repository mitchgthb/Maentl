using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IEmailActivityService
    {
        Task<List<EmailActivityDto>> GetForUserAsync(string userEmail);
        Task<EmailActivityDto?> GetByIdAsync(Guid id);
        Task<bool> SaveAsync(EmailActivityDto dto);
        Task<bool> DeleteAsync(Guid id);

    }
}
