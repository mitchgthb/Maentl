using DTO;
using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Strategy
{
    public class DocumentEditStrategy : IEffortStrategy
    {
        public double CalculateEffortMinutes(object activityDto)
        {
            if (activityDto is not DocumentDto doc)
                return 0;

            // Smart heuristic based on title/content
            if (doc.Title?.ToLower().Contains("report") == true ||
                doc.Title?.ToLower().Contains("proposal") == true)
                return 60;

            if (doc.Title?.ToLower().Contains("invoice") == true)
                return 20;

            return 30; // fallback
        }

        public double EstimateEffort(object source)
        {
            if (source is not Document doc) return 0;

            // If modified recently or certain type, we can adjust
            var baseMinutes = 30.0;

            if (doc.Title?.ToLower().Contains("contract") == true)
                baseMinutes += 15;

            // Example: if complexity tagging exists in future
            if (doc.Description?.Contains("complex") == true)
                baseMinutes *= 1.25;

            return Math.Round(baseMinutes / 60.0, 2); // convert to hours
        }
    }
}
