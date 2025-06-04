using DTO;
using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOAdapters
{
    public static class ProjectMapper
    {
        public static ProjectDto ToDto(Project entity)
        {
            if (entity == null) return null;

            return new ProjectDto
            {
                Id = entity.Id,
                Name = entity.Name,
                OwnerEmail = entity.OwnerEmail,
                Status = entity.Status,
                Deadline = entity.Deadline
            };
        }

        public static Project ToEntity(ProjectDto dto)
        {
            if (dto == null) return null;

            return new Project
            {
                Id = dto.Id,
                Name = dto.Name,
                OwnerEmail = dto.OwnerEmail,
                Status = dto.Status,
                Deadline = dto.Deadline
            };
        }
    }
}
