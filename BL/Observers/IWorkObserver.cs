using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Observers
{
    public interface IWorkObserver
    {
        Task NotifyWorkCreatedAsync(int workEntryId);
        Task NotifyWorkApprovedAsync(int workEntryId);
        Task NotifyWorkDeletedAsync(int workEntryId);
    }
}
