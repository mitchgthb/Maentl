using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Observers
{
    public class WorkObserverHubBridge
    {
        private readonly IEnumerable<IWorkObserver> _observers;

        public WorkObserverHubBridge(IEnumerable<IWorkObserver> observers)
        {
            _observers = observers;
        }

        public async Task NotifyCreatedAsync(int id)
        {
            foreach (var observer in _observers)
                await observer.NotifyWorkCreatedAsync(id);
        }

        public async Task NotifyApprovedAsync(int id)
        {
            foreach (var observer in _observers)
                await observer.NotifyWorkApprovedAsync(id);
        }

        public async Task NotifyDeletedAsync(int id)
        {
            foreach (var observer in _observers)
                await observer.NotifyWorkDeletedAsync(id);
        }
    }
}
