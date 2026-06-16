using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace VendorAccessGovernance.Core.Entities
{
    public class ExternalWorker
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;   
        public int VendorId { get; set; }
        public Vendor VendorName { get; set; }

        public List<AccessRequest> AccessRequests { get; set; } = new List<AccessRequest>();
    }
}
