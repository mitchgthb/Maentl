using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Maentl.SQL.Model
{
    public class EmailActivity : AuditableEntityBase<Guid>
    {
        [Required]
        public string MessageId { get; set; } // Unique ID from Graph or Outlook

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Recipient { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public DateTime SentAt { get; set; }

        public int EstimatedEffortMinutes { get; set; } = 0;

        public string ParsingStrategy { get; set; }

        public string Tags { get; set; }

        [Required]
        public string UserEmail { get; set; }

        public string Body { get; set; }

        public virtual ICollection<EmailAttachment> Attachments { get; set; } = new List<EmailAttachment>();

        public int? WorkEntryId { get; set; }

        [ForeignKey("WorkEntryId")]
        public WorkEntry RelatedWorkEntry { get; set; }
    }
}
