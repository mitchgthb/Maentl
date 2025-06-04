using DTO;

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
    }
}
