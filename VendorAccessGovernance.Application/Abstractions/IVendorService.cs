using System;
using System.Collections.Generic;
using System.Text;

namespace VendorAccessGovernance.Application.Abstractions
{
    public interface IVendorService
    {
        Task<int> EnsureVendorAsync(string vendorName, CancellationToken cancellationToken = default);
    }
}
