using Enums;
using System.ComponentModel.DataAnnotations;

namespace Maentl.SQL.Model
{
    public class Project : AuditableEntityBase<int>
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [EmailAddress]
        public string OwnerEmail { get; set; }

        [Required]
        public ProjectStatus Status { get; set; } = ProjectStatus.NotStarted;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? Deadline { get; set; }

        public bool IsArchived { get; set; } = false;

        // Reverse Navigation
        public ICollection<WorkEntry> WorkEntries { get; set; } = new List<WorkEntry>();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
