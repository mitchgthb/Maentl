using Enums;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Strategy
{
    public class EffortStrategyContext
    {
        private readonly IEffortStrategy _strategy;

        public EffortStrategyContext(IEffortStrategy strategy)
        {
            _strategy = strategy;
        }

        public double ExecuteStrategy(object activityDto)
        {
            return _strategy.CalculateEffortMinutes(activityDto);
        }

        public static IEffortStrategy ResolveStrategy(WorkSource source)
        {
            return source switch
            {
                WorkSource.Email => new EmailEffortStrategy(),
                WorkSource.Calendar => new CalendarEffortStrategy(),
                WorkSource.Document => new DocumentEditStrategy(),
                _ => throw new NotSupportedException("Unsupported work source.")
            };
        }
    }
}
