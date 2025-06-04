using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    public enum ProjectStatus
    {
        NotStarted = 0, //  Planning phase; no work assigned yet
        Active = 1,     //	Project is underway
        OnHold = 2,     //	Temporarily paused
        Completed = 3,  //  Fully executed and closed
        Cancelled = 4,  //  Ended before completion
        Archived = 5    //  Not active but retained for audit/history
    }
}
