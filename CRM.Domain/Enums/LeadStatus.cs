using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Enums
{
    public enum LeadStatus
    {
        New,
        NotInterested,
        InProgress,
        Converted,  // has completed at least 1 step of the buy
        Closed
    }
}
