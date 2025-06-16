using DTO;
using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOAdapters
{
    public static class EmailAttachmentMapper
    {
        public static EmailAttachmentDto ToDto(EmailAttachment entity)
        {
            if (entity == null) return null;

            return new EmailAttachmentDto
            {
                FileName = entity.FileName,
                ContentType = entity.ContentType,
                FileSize = entity.FileSize
                // No ContentBytes – they don’t exist in DB model
            };
        }

        public static EmailAttachment ToEntity(EmailAttachmentDto dto, Guid emailActivityId)
        {
            if (dto == null) return null;

            return new EmailAttachment
            {
                Id = Guid.NewGuid(),
                FileName = dto.FileName,
                ContentType = dto.ContentType,
                FileSize = dto.ContentBytes?.Length ?? 0,
                EmailActivityId = emailActivityId
            };
        }

        public static List<EmailAttachment> ToEntityList(IEnumerable<EmailAttachmentDto> dtos, Guid emailActivityId)
        {
            return dtos?.Select(dto => ToEntity(dto, emailActivityId)).ToList() ?? new List<EmailAttachment>();
        }

        public static List<EmailAttachmentDto> ToDtoList(IEnumerable<EmailAttachment> entities)
        {
            return entities?.Select(ToDto).ToList() ?? new List<EmailAttachmentDto>();
        }
    }
}
