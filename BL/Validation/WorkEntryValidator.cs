using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Validation
{
    public static class WorkEntryValidator
    {
        public static bool IsValid(WorkEntry entry, out List<string> errors)
        {
            errors = new();

            if (string.IsNullOrWhiteSpace(entry.UserEmail))
                errors.Add("User email is required.");

            if (entry.StartTime >= entry.EndTime)
                errors.Add("Start time must be before end time.");

            if (entry.EffortHours < 0)
                errors.Add("Effort hours cannot be negative.");

            if (entry.ProjectId.HasValue && entry.RelatedProject == null)
                errors.Add("ProjectId is set but RelatedProject is null.");

            return !errors.Any();
        }
    }
}
