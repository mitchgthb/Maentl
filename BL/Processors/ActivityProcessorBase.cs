using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Processors
{
    public abstract class ActivityProcessorBase<T>
    {
        protected readonly IWorkEntryService _workService;
        protected readonly IEffortService _effortService;

        protected ActivityProcessorBase(IWorkEntryService workService, IEffortService effortService)
        {
            _workService = workService;
            _effortService = effortService;
        }

        public abstract Task ProcessAsync(T activityDto);

        protected void LogProcessing(string msg)
        {
            // Unified logging here
        }
    }

}
