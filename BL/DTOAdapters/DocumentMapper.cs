using DocumentFormat.OpenXml.Vml.Office;
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
                Type = entity.Type,
                CreatedAt = entity.CreatedAt,
                ModifiedAt = entity.ModifiedAt,
                CreatedBy = entity.CreatedBy,
                WorkEntryId = entity.WorkEntryId,
                ProjectId = entity.ProjectId,

                WorkEntrySummary = entity.RelatedWorkEntry?.EffortMethod.ToString(), // UI only
                RelatedProject = entity.RelatedProject?.Name, // UI only

                FileName = entity.FileName,
                SharePointId = entity.SharePointId,
                PreviewUrl = entity.PreviewUrl,
                FileSize = entity.FileSize,
                ContentType = entity.ContentType
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
                Type = dto.Type,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt,
                CreatedBy = dto.CreatedBy,
                WorkEntryId = dto.WorkEntryId,
                ProjectId = dto.ProjectId,
                FileName = dto.FileName,
                SharePointId = dto.SharePointId,
                PreviewUrl = dto.PreviewUrl,
                FileSize = dto.FileSize,
                ContentType = dto.ContentType
            };
        }
    }

}
