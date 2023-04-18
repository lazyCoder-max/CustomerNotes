using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Enums
{
    public enum RequestStatus
    {
        Completed = 0,
        Loading = 1,
        Loaded  = 2,
        Failed  = 3,
        Timeout = 4,
        Ideal = 5
    }
}
