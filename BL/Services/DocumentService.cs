using BL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class DocumentService : IDocumentService
    {
        public Task<IEnumerable<DocumentDto>> GetAllForUserAsync(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<DocumentDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DocumentDto> UploadAsync(DocumentDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LinkToWorkEntryAsync(Guid documentId, int workEntryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(DocumentDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
