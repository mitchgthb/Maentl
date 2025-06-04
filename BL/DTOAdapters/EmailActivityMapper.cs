using DTO;
using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOAdapters
{
    public static class EmailActivityMapper
    {
        public static EmailActivityDto ToDto(EmailActivity entity)
        {
            if (entity == null) return null;

            return new EmailActivityDto
            {
                Id = entity.Id,
                MessageId = entity.MessageId,
                Sender = entity.Sender,
                Recipient = entity.Recipient,
                Subject = entity.Subject,
                SentAt = entity.SentAt,
                EstimatedEffortMinutes = entity.EstimatedEffortMinutes,
                ParsingStrategy = entity.ParsingStrategy,
                Tags = entity.Tags,
                UserEmail = entity.UserEmail,
                WorkEntryId = entity.WorkEntryId
            };
        }

        public static EmailActivity ToEntity(EmailActivityDto dto)
        {
            if (dto == null) return null;

            return new EmailActivity
            {
                Id = dto.Id,
                MessageId = dto.MessageId,
                Sender = dto.Sender,
                Recipient = dto.Recipient,
                Subject = dto.Subject,
                SentAt = dto.SentAt,
                EstimatedEffortMinutes = dto.EstimatedEffortMinutes,
                ParsingStrategy = dto.ParsingStrategy,
                Tags = dto.Tags,
                UserEmail = dto.UserEmail,
                WorkEntryId = dto.WorkEntryId
            };
        }
    }
}
