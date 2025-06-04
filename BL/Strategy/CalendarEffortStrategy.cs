using DTO;

namespace BL.Strategy
{
    public class CalendarEffortStrategy : IEffortStrategy
    {
        public double CalculateEffortMinutes(object activityDto)
        {
            var meeting = activityDto as CalendarEventDto; // you'll need to define this later

            if (meeting == null) return 0;

            return (meeting.EndTime - meeting.StartTime).TotalMinutes;
        }
    }
}
