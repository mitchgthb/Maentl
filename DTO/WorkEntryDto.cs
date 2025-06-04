using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WorkEntryDto
    {
        public int Id { get; set; }

        public string UserEmail { get; set; }

        public WorkSource SourceType { get; set; }
        public string SourceReference { get; set; }

        public WorkTypeEnum WorkType { get; set; }
        public WorkState Status { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public double EffortHours { get; set; }
        public EffortMethod EffortMethod { get; set; }

        public bool IsBillable { get; set; }
        public bool IsApproved { get; set; }

        public string ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }

        public int? ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string Notes { get; set; }
    }
}
