using BL.DTOAdapters;
using BL.Interfaces;
using DTO;
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
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project, int> _projectRepo;

        public ProjectService(IRepository<Project, int> projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await _projectRepo.Query()
                .Where(p => !p.IsArchived)
                .ToListAsync();

            return projects.Select(ProjectMapper.ToDto);
        }

        public async Task<ProjectDto> GetByIdAsync(int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);
            return project == null ? null : ProjectMapper.ToDto(project);
        }

        public async Task<ProjectDto> CreateAsync(ProjectDto dto)
        {
            var entity = ProjectMapper.ToEntity(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await _projectRepo.AddAsync(entity);

            return ProjectMapper.ToDto(entity);
        }

        public async Task<bool> ArchiveAsync(int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);
            if (project == null) return false;

            project.IsArchived = true;
            await _projectRepo.UpdateAsync(project);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);
            if (project == null) return false;

            await _projectRepo.DeleteAsync(project);
            return true;
        }
    }
}
