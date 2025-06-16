using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Enums;
using System.Text.Json;

namespace Maentl.SQL.Model
{
    public class Document : AuditableEntityBase<Guid>
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(1000)]
        public string FilePath { get; set; }  // SharePoint URL or local path

        [Required]
        public SourceSystem SourceSystem { get; set; } // Changed from string → Enum

        [Required]
        public DocumentType Type { get; set; }

        [Required]
        [EmailAddress]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? WorkEntryId { get; set; }

        [ForeignKey("WorkEntryId")]
        public WorkEntry RelatedWorkEntry { get; set; }

        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project RelatedProject { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        // SharePoint-assigned ID (e.g., ListItem ID or DriveItem ID)
        [StringLength(255)]
        public string SharePointId { get; set; }

        // SharePoint thumbnail/preview URL
        [StringLength(1000)]
        public string PreviewUrl { get; set; }

        // File size in bytes (optional limit)
        public int FileSize { get; set; }

        // MIME type (e.g., application/pdf)
        [StringLength(100)]
        public string ContentType { get; set; }
    }
}