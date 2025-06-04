using DTO;
using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOAdapters
{
    public static class DocumentMapper
    {
        public static DocumentDto ToDto(Document entity)
        {
            if (entity == null) return null;

            return new DocumentDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                FilePath = entity.FilePath,
                SourceSystem = entity.SourceSystem,
                CreatedAt = entity.CreatedAt,
                ModifiedAt = entity.ModifiedAt,
                CreatedBy = entity.CreatedBy,
                WorkEntryId = entity.WorkEntryId,
                ProjectId = entity.ProjectId,
                ProjectName = entity.RelatedProject?.Name,
                WorkEntrySummary = entity.RelatedWorkEntry?.EffortMethod.ToString()
            };
        }

        public static Document ToEntity(DocumentDto dto)
        {
            if (dto == null) return null;

            return new Document
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                FilePath = dto.FilePath,
                SourceSystem = dto.SourceSystem,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt,
                CreatedBy = dto.CreatedBy,
                WorkEntryId = dto.WorkEntryId,
                ProjectId = dto.ProjectId
            };
        }
    }
}
