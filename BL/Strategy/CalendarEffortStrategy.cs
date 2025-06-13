using DTO;

namespace BL.Strategy
{
    public class CalendarEffortStrategy : IEffortStrategy
    {
        public double CalculateEffortMinutes(object activityDto)
        {
            if (activityDto is not CalendarEventDto meeting)
                return 0;

            if (meeting.EndTime <= meeting.StartTime)
                return 0;

            double baseMinutes = (meeting.EndTime - meeting.StartTime).TotalMinutes;

            // Heuristic adjustments
            if (meeting.IsPrivate)
                baseMinutes *= 1.1;

            if ((meeting.AttendeeEmail?.ToLower().Contains("ceo") ?? false) ||
                (meeting.OrganizerEmail?.ToLower().Contains("director") ?? false))
                baseMinutes *= 1.15;

            return Math.Round(baseMinutes, 2);
        }

        public double EstimateEffort(object source)
        {
            return CalculateEffortMinutes(source) / 60.0;
        }
    }
}
