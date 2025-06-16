using Enums;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL.Strategy.Email;

namespace BL.Strategy
{
    public class EffortStrategyContext
    {
        private readonly IEffortStrategy _strategy;
        private readonly Dictionary<Type, IEffortStrategy> _strategies;

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

        public EffortStrategyContext(IEnumerable<IEffortStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(
                s => s.GetType().GetInterfaces()
                      .First(i => i.IsGenericType && i.GetGenericArguments().Length == 1)
                      .GetGenericArguments()[0],
                s => s
            );
        }

        public double EstimateEffort(object source)
        {
            if (source == null) return 0;

            var type = source.GetType();
            if (_strategies.TryGetValue(type, out var strategy))
            {
                return strategy.EstimateEffort(source);
            }

            return 0;
        }
    }
}
