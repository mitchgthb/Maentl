using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IEmailAttachmentService
    {
        Task SaveAttachmentsAsync(IEnumerable<EmailAttachmentDto> attachments, int? projectId);
    }

}
