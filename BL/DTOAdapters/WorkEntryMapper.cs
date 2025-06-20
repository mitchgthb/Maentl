﻿using DTO;
using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOAdapters
{
    public static class WorkEntryMapper
    {
        public static WorkEntryDto ToDto(WorkEntry entity)
        {
            if (entity == null) return null;

            return new WorkEntryDto
            {
                Id = entity.Id,
                UserEmail = entity.UserEmail,
                SourceType = entity.SourceType,
                SourceReference = entity.SourceReference,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                EffortHours = entity.EffortHours,
                WorkType = entity.WorkType,
                Status = entity.Status,
                IsBillable = entity.IsBillable,
                IsApproved = entity.IsApproved,
                ApprovedBy = entity.ApprovedBy,
                ApprovedAt = entity.ApprovedAt,
                ProjectId = entity.ProjectId,
                ProjectName = entity.RelatedProject?.Name
            };
        }

        public static WorkEntry ToEntity(WorkEntryDto dto)
        {
            if (dto == null) return null;

            return new WorkEntry
            {
                Id = dto.Id,
                UserEmail = dto.UserEmail,
                SourceType = dto.SourceType,
                SourceReference = dto.SourceReference,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                EffortHours = dto.EffortHours,
                WorkType = dto.WorkType,
                Status = dto.Status,
                IsBillable = dto.IsBillable,
                IsApproved = dto.IsApproved,
                ApprovedBy = dto.ApprovedBy,
                ApprovedAt = dto.ApprovedAt,
                ProjectId = dto.ProjectId
            };
        }

        public static void UpdateEntity(WorkEntryDto dto, WorkEntry entity)
        {
            entity.StartTime = dto.StartTime;
            entity.EndTime = dto.EndTime;
            entity.Notes = dto.Notes;
            entity.Status = dto.Status;
            entity.WorkType = dto.WorkType;
            entity.IsBillable = dto.IsBillable;
            entity.IsApproved = dto.IsApproved;
            entity.ApprovedBy = dto.ApprovedBy;
            entity.ApprovedAt = dto.ApprovedAt;
            entity.ProjectId = dto.ProjectId;
            entity.SourceType = dto.SourceType;
            entity.SourceReference = dto.SourceReference;
            entity.EffortHours = dto.EffortHours;
        }

    }
}
