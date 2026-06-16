using System;
using System.Collections.Generic;
using System.Text;

namespace VendorAccessGovernance.Core.Entities
{
    public class AccessRequest
    {
        public int Id { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string InternalSponsor { get; set; } = string.Empty;
        public AccessRequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int ExternalWorkerId { get; set; }
        public ExternalWorker WorkerRequest = null!;
    }
}
