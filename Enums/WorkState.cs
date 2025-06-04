using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    public enum WorkState
    {
        Draft = 0,
        Submited = 10,
        Approved = 100,
        Billed = 200,
        Rejected = -100
    }
}
