using DocumentFormat.OpenXml.Spreadsheet;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Enums;


namespace Maentl.SQL.Model
{
    public class WorkEntry : AuditableEntityBase<int>
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public WorkSource SourceType { get; set; }

        [MaxLength(256)]
        public string SourceReference { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public double EffortHours { get; set; }

        [Required]
        public EffortMethod EffortMethod { get; set; } = EffortMethod.Manual;

        [Required]
        public WorkTypeEnum WorkType { get; set; }

        [Required]
        public WorkState Status { get; set; } = WorkState.Draft;

        [MaxLength(1000)]
        public string Notes { get; set; }

        public bool IsBillable { get; set; } = true;

        public bool IsApproved { get; set; } = false;

        public string ApprovedBy { get; set; }

        public DateTime? ApprovedAt { get; set; }

        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project RelatedProject { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<EmailActivity> EmailActivities { get; set; }
    }
}
