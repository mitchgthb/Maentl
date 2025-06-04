using DTO;
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
            var doc = activityDto as DocumentDto;

            if (doc == null) return 0;

            // Default assumption: editing a doc = 30 minutes
            return 30;
        }
    }
}
