using BL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ProjectService : IProjectService
    {
        public Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> CreateAsync(ProjectDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ArchiveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
