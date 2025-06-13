using BL.DTOAdapters;
using BL.Interfaces;
using BL.Observers;
using DTO;
using Maentl.SQL.Repository.WorkEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class WorkEntryService : IWorkEntryService
    {
        private readonly IWorkEntryRepository _repository;
        private readonly WorkObserverHubBridge _observer;

        public WorkEntryService(IWorkEntryRepository repository, WorkObserverHubBridge observer)
        {
            _repository = repository;
            _observer = observer;
        }

        public async Task<IEnumerable<WorkEntryDto>> GetAllByUserAsync(string userEmail)
        {
            var entries = await _repository.GetByUserAsync(userEmail);
            return entries.Select(WorkEntryMapper.ToDto);
        }

        public async Task<WorkEntryDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : WorkEntryMapper.ToDto(entity);
        }

        public async Task<WorkEntryDto> CreateAsync(WorkEntryDto dto)
        {
            var entity = WorkEntryMapper.ToEntity(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await _repository.AddAsync(entity);
            await _observer.NotifyCreatedAsync(entity.Id);

            return WorkEntryMapper.ToDto(entity);
        }

        public async Task<bool> SaveAsync(WorkEntryDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return false;

            WorkEntryMapper.UpdateEntity(dto, entity);
            await _repository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> ApproveAsync(int id, string approverEmail)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            entity.IsApproved = true;
            entity.ApprovedBy = approverEmail;
            entity.ApprovedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(entity);
            await _observer.NotifyApprovedAsync(id);

            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            await _observer.NotifyDeletedAsync(id);

            return true;
        }

    }
}
