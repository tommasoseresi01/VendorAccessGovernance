using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Core;

namespace VendorAccessGovernance.Application.DTOs
{
    public class AccessRequestDto
    {
        public int Id { get; set; }
        public string VendorName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string InternalSponsor { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public int ExternalWorkerid { get; set; }
        public string WorkerFullName { get; set; } = string.Empty;
    }
}
