using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Application.DTOs;

namespace VendorAccessGovernance.Application.Abstractions
{
    public interface IVendorService
    {
        Task<int> EnsureVendorAsync(string vendorName, CancellationToken cancellationToken = default);

        Task<List<VendorDto>> GetAllAsync();
    }
}
