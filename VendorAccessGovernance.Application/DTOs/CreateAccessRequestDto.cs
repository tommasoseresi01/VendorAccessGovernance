using System;
using System.Collections.Generic;
using System.Text;

namespace VendorAccessGovernance.Application.DTOs
{
    public class CreateAccessRequestDto
    {
        public int ExternalWorkerId { get; set; }
        public String Reason { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string InternalSponsor { get; set; } = string.Empty;
    }
}
