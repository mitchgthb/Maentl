using BL.Interfaces;
using DTO;
using Maentl.SQL.Model;
using Enums;
using BL.DTOAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class EmailAttachmentService : IEmailAttachmentService
    {
        private readonly IDocumentService _documentService;

        public EmailAttachmentService(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task SaveAttachmentsAsync(IEnumerable<EmailAttachmentDto> attachments, int? projectId)
        {
            if (attachments == null || !attachments.Any())
                return;

            foreach (var attachment in attachments)
            {
                var document = new Document
                {
                    Title = attachment.FileName,
                    ContentType = attachment.ContentType,
                    CreatedAt = DateTime.UtcNow,
                    ProjectId = projectId,
                    SourceSystem = SourceSystem.Outlook,
                    // You can add more metadata if needed
                };

                // Convert Document to DocumentDto (assuming a mapper exists)
                await _documentService.SaveDocumentAsync(document, attachment.ContentBytes);
            }
        }

        public Task SaveAttachmentsAsync(IEnumerable<EmailAttachmentDto> attachments, Guid? projectId)
        {
            throw new NotImplementedException();
        }
    }
}
