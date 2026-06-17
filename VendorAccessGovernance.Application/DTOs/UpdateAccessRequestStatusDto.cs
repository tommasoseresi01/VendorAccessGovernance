using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Core;

namespace VendorAccessGovernance.Application.DTOs
{
    public class UpdateAccessRequestStatusDto
    {
        public AccessRequestStatus NewStatus { get; set; }
    }
}
