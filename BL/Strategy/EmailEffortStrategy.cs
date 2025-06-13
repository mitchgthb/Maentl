using DTO;
using Maentl.SQL.Model;

namespace BL.Strategy
{
    public class EmailEffortStrategy : IEffortStrategy
    {
        public double CalculateEffortMinutes(object activityDto)
        {
            var email = activityDto as EmailActivityDto;

            if (email == null) return 0;

            // Simple heuristic: longer subjects or important senders == more effort
            if (email.Subject.Contains("report") || email.Sender.Contains("partner"))
                return 45;

            return 30; // default
        }
        public double EstimateEffort(object source)
        {
            if (source is not EmailActivity email) return 0;
            int wordCount = email.Subject?.Split(' ').Length ?? 0;
            return Math.Max(1.0, wordCount / 20.0);
        }
    }
}
