using BL.Interfaces;
using DTO;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public class DocumentFacade
    {
        private readonly IDocumentService _documentService;
        private readonly IWorkEntryService _workService;

        public DocumentFacade(
            IDocumentService documentService,
            IWorkEntryService workService)
        {
            _documentService = documentService;
            _workService = workService;
        }

        public async Task<DocumentDto> UploadAndLinkAsync(DocumentDto documentDto, bool createWorkEntry = false)
        {
            var saved = await _documentService.UploadAsync(documentDto);

            if (createWorkEntry)
            {
                var workDto = new WorkEntryDto
                {
                    UserEmail = saved.CreatedBy,
                    StartTime = saved.CreatedAt,
                    EndTime = saved.CreatedAt.AddMinutes(30), // assume default effort
                    SourceType = WorkSource.Document,
                    SourceReference = saved.Id.ToString(),
                    EffortHours = 0.5,
                    WorkType = WorkTypeEnum.Internal,
                    Status = WorkState.Draft,
                    Notes = $"Initial upload of document: {saved.Title}"
                };

                var entry = await _workService.CreateAsync(workDto);
                await _documentService.LinkToWorkEntryAsync(saved.Id, entry.Id);
            }

            return saved;
        }
    }
}
