using BL.Interfaces;
using Maentl.SQL.Model;

namespace BL.Strategy
{
    public class EffortService : IEffortService
    {
        public double EstimateEffortFromEmail(EmailActivity email)
        {
            // Default logic: 1 minute per 20 words in subject
            if (string.IsNullOrWhiteSpace(email.Subject)) return 1.0;
            int wordCount = email.Subject.Split(' ').Length;
            return Math.Round(Math.Max(1.0, wordCount / 20.0), 2);
        }

        public double EstimateEffortFromCalendar(CalendarEvent evt)
        {
            // Effort = Meeting duration in hours
            return (evt.EndTime - evt.StartTime).TotalHours;
        }

        public double EstimateEffortFromDocument(Document doc)
        {
            // Placeholder: 30 mins default
            return 0.5;
        }

        public double EstimateEffortHours(object source)
        {
            return source switch
            {
                EmailActivity email => EstimateEffortFromEmail(email),
                CalendarEvent cal => EstimateEffortFromCalendar(cal),
                Document doc => EstimateEffortFromDocument(doc),
                _ => 0.0
            };
        }

        public decimal CalculateEffortCost(WorkEntry entry)
        {
            double hours = entry.EffortHours;
            decimal rate = GetUserRate(entry.UserEmail);
            double complexity = GetComplexityFactor(entry);
            return Math.Round((decimal)hours * rate * (decimal)complexity, 2);
        }

        public decimal GetUserRate(string userEmail)
        {
            // Default hardcoded fallback; can later query database
            return userEmail.Contains("manager") ? 150m : 100m;
        }

        public double GetComplexityFactor(WorkEntry entry)
        {
            // Future: parse tags/notes or use AI
            if (entry.Notes?.Contains("complex") == true)
                return 1.25;
            return 1.0;
        }
    }
}
