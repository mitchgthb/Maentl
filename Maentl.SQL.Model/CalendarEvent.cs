using Enums;
using System.ComponentModel.DataAnnotations;

namespace Maentl.SQL.Model
{
    public class CalendarEvent : AuditableEntityBase<Guid>
    {
        [Required]
        [StringLength(200)]
        public string Subject { get; set; }

        [StringLength(300)]
        public string Location { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [EmailAddress]
        public string OrganizerEmail { get; set; }

        [EmailAddress]
        public string AttendeeEmail { get; set; }

        public bool IsPrivate { get; set; } = false;

        [Required]
        public SourceSystem SourceSystem { get; set; } // Enum, e.g., Outlook

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } // Owner of this calendar event

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
