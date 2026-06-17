using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Core.Entities;

namespace VendorAccessGovernance.Application.Abstractions
{
    public interface IAccessRequestRepository
    {
        Task<AccessRequest> AddAsync(AccessRequest accessRequest);
        Task<List<AccessRequest>> GetAllAsync();
        Task<AccessRequest?> GetByIdAsync(int id, CancellationToken ct = default);
        Task UpdateAsync(AccessRequest request, CancellationToken ct = default);
    }
}
