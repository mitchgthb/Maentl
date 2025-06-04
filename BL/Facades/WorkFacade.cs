using DTO;
using Enums;
using BL.Interfaces;
using BL.Services;
using BL.Strategy;
using Maentl.SQL.Model;

namespace BL.Facade
{
    public class WorkFacade
    {
        private readonly IWorkEntryService _workService;
        private readonly IUserService _userService;
        private readonly IEffortStrategy _effortStrategy; // Injected dynamically per context (e.g., Email)

        public WorkFacade(
            IWorkEntryService workService,
            IUserService userService,
            IEffortStrategy effortStrategy)
        {
            _workService = workService;
            _userService = userService;
            _effortStrategy = effortStrategy;
        }

        public async Task<WorkEntryDto> ParseAndCreateWorkFromEmailAsync(EmailActivity email)
        {
            var effort = _effortStrategy.CalculateEffortMinutes(email);

            var dto = new WorkEntryDto
            {
                UserEmail = email.UserEmail,
                StartTime = email.SentAt,
                EndTime = email.SentAt.AddMinutes(effort),
                EffortHours = effort / 60.0,
                SourceType = WorkSource.Email,
                SourceReference = email.MessageId,
                Notes = email.Subject,
                WorkType = WorkTypeEnum.Billable,
                Status = WorkState.Draft
            };

            return await _workService.CreateAsync(dto);
        }
    }
}
