using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmailActivityDto
    {
        public Guid Id { get; set; }

        public string MessageId { get; set; }

        public string Subject { get; set; }

        public DateTime SentAt { get; set; }

        public int EstimatedEffortMinutes { get; set; }

        public string Sender { get; set; }

        public string Recipient { get; set; }

        public string ParsingStrategy { get; set; }

        public string Tags { get; set; }

        public string UserEmail { get; set; }

        public int? WorkEntryId { get; set; }

        // Optional (for display)
        public string WorkEntrySummary { get; set; } // e.g., EffortMethod or duration summary
    }
}
