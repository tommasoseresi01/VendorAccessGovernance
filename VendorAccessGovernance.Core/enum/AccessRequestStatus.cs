using System;
using System.Collections.Generic;
using System.Text;

namespace VendorAccessGovernance.Core
{
    public enum AccessRequestStatus
{
        PendingApproval = 0,
        Approved = 1,
        Rejected = 2,
        Canceled = 3
    }
}
