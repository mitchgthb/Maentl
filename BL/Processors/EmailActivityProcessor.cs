using BL.DTOAdapters;
using BL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace BL.Processors
{
    public class EmailActivityProcessor : ActivityProcessorBase<EmailActivityDto>, IActivityProcessor<EmailActivityDto>
    {
        private readonly IEmailClassifierService _classifierService;
        private readonly IEmailAttachmentService _attachmentService;

        public EmailActivityProcessor(
            IWorkEntryService workService,
            IEffortService effortService,
            IEmailClassifierService classifierService,
            IEmailAttachmentService attachmentService)
            : base(workService, effortService)
        {
            _classifierService = classifierService;
            _attachmentService = attachmentService;
        }

        public override async Task ProcessAsync(EmailActivityDto emailDto)
        {
            LogProcessing($"Processing email from {emailDto.Sender}");

            //Map to domain model before passing to BL services
            var emailEntity = EmailActivityMapper.ToEntity(emailDto);

            var effort = _effortService.EstimateEffortFromEmail(emailEntity);
            var workTypeString = _classifierService.ClassifyWorkType(emailDto);
            if (!Enum.TryParse<WorkTypeEnum>(workTypeString, out var workType))
            {
                workType = WorkTypeEnum.Internal; // fallback or handle as appropriate
            }
            var complexity = _classifierService.EvaluateComplexity(emailDto);

            var workEntry = await _workService.CreateOrUpdateWorkEntryAsync(
                emailDto.UserEmail,
                WorkSource.Email,
                emailDto.MessageId,
                emailDto.SentAt,
                emailDto.SentAt.AddMinutes(effort * 60),
                effort,
                workType,
                complexity,
                EffortMethod.Automatic,
                emailDto.Subject,
                emailDto.ProjectId
            );

            if (emailDto.Attachments?.Any() == true)
            {
                //// Map EmailAttachment to EmailAttachmentDto
                //var attachmentDtos = emailDto.Attachments
                //    .Select(a => new EmailAttachmentDto
                //    {
                //        ContentType = a.ContentType
                //        // Map other properties as needed
                //    });
                var attachmentDtos = EmailAttachmentMapper.ToDtoList(emailEntity.Attachments);
                await _attachmentService.SaveAttachmentsAsync(attachmentDtos, workEntry.ProjectId);
            }

            // Optionally persist raw email entity if needed
        }
    }

}
