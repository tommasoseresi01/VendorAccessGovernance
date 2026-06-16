using System;
using System.Collections.Generic;
using System.Text;

namespace VendorAccessGovernance.Core.Entities
{
    public class Vendor
    {
        public int Id { get; set; }
        public string NameVendor { get; set; } = string.Empty;
        public string VatNumber { get; set; } = string.Empty; //Partita IVA
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public List<ExternalWorker> MyWorkers = new List<ExternalWorker>();
    }
}
