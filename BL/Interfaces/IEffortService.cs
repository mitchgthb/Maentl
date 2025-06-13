using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IEffortService
    {
        double EstimateEffortHours(object source); // general fallback

        double EstimateEffortFromEmail(EmailActivity email);
        double EstimateEffortFromCalendar(CalendarEvent evt);
        double EstimateEffortFromDocument(Document doc);

        decimal CalculateEffortCost(WorkEntry workEntry);

        decimal GetUserRate(string userEmail);
        double GetComplexityFactor(WorkEntry workEntry);
    }

}
