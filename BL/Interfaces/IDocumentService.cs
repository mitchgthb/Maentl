using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentDto>> GetAllForUserAsync(string userEmail);
        Task<DocumentDto> GetByIdAsync(Guid id);
        Task<DocumentDto> UploadAsync(DocumentDto dto);
        Task<bool> LinkToWorkEntryAsync(Guid documentId, int workEntryId);
        Task<bool> SaveAsync(DocumentDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
