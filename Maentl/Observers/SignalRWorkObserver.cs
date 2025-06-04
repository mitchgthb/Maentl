using BL.Observers;
using Maentl.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maentl.WebApi.Observers
{
    public class SignalRWorkObserver : IWorkObserver
    {
        private readonly IHubContext<WorkObserverHub> _hubContext;

        public SignalRWorkObserver(IHubContext<WorkObserverHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyWorkCreatedAsync(int workEntryId)
        {
            await _hubContext.Clients.All.SendAsync("WorkCreated", workEntryId);
        }

        public async Task NotifyWorkApprovedAsync(int workEntryId)
        {
            await _hubContext.Clients.All.SendAsync("WorkApproved", workEntryId);
        }

        public async Task NotifyWorkDeletedAsync(int workEntryId)
        {
            await _hubContext.Clients.All.SendAsync("WorkDeleted", workEntryId);
        }
    }
}
