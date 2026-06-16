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
    }
}
