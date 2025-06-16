using BL.DTOAdapters;
using BL.Interfaces;
using DTO;
using Enums;
using Maentl.SQL.Model;
using Maentl.SQL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepository<Document, Guid> _documentRepo;
        private readonly IRepository<WorkEntry, int> _workRepo;
        private readonly ISharePointService _sharePointService;

        public DocumentService(IRepository<Document, Guid> documentRepo, IRepository<WorkEntry, int> workRepo)
        {
            _documentRepo = documentRepo;
            _workRepo = workRepo;
        }

        public async Task<IEnumerable<DocumentDto>> GetAllForUserAsync(string userEmail)
        {
            var docs = await _documentRepo.Query()
                .Include(d => d.RelatedProject)
                .Include(d => d.RelatedWorkEntry)
                .Where(d => d.CreatedBy == userEmail)
                .ToListAsync();

            return docs.Select(DocumentMapper.ToDto).ToList();
        }

        public async Task<DocumentDto> GetByIdAsync(Guid id)
        {
            var entity = await _documentRepo.Query()
                .Include(d => d.RelatedProject)
                .Include(d => d.RelatedWorkEntry)
                .FirstOrDefaultAsync(d => d.Id == id);

            return DocumentMapper.ToDto(entity);
        }

        public async Task<DocumentDto> UploadAsync(DocumentDto dto)
        {
            var entity = DocumentMapper.ToEntity(dto);
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
                entity.CreatedAt = DateTime.UtcNow;
            }

            await _documentRepo.AddAsync(entity);
            return DocumentMapper.ToDto(entity);
        }

        public async Task<bool> LinkToWorkEntryAsync(Guid documentId, int workEntryId)
        {
            var doc = await _documentRepo.GetByIdAsync(documentId);
            var work = await _workRepo.GetByIdAsync(workEntryId);

            if (doc == null || work == null) return false;

            doc.WorkEntryId = workEntryId;
            await _documentRepo.UpdateAsync(doc);
            return true;
        }

        public async Task<bool> SaveAsync(DocumentDto dto)
        {
            var entity = await _documentRepo.GetByIdAsync(dto.Id);
            if (entity == null) return false;

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.FilePath = dto.FilePath;
            entity.SourceSystem = entity.SourceSystem = dto.SourceSystem;
            entity.ModifiedAt = DateTime.UtcNow;

            await _documentRepo.UpdateAsync(entity);
            return true;
        }

        public async Task SaveDocumentAsync(Document document, byte[] contentBytes)
        {
            // 1. Upload to SharePoint
            var uploadResult = await _sharePointService.UploadFileAsync(
                contentBytes,
                document.FileName,
                document.ProjectId);

            // 2. Apply SharePoint metadata to Document entity
            document.FilePath = uploadResult.FileUrl;         // This is the full URL to the file
            document.SharePointId = uploadResult.DocId;       // SharePoint internal ID (e.g., ListItem ID)
            document.SourceSystem = SourceSystem.SharePoint;  // Enum value
            document.ModifiedAt = DateTime.UtcNow;

            // 3. Save to database
            await _documentRepo.AddAsync(document);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _documentRepo.GetByIdAsync(id);
            if (entity == null) return false;

            await _documentRepo.DeleteAsync(entity);
            return true;
        }
    }
}
