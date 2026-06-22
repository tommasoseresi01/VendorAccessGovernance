using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Application.DTOs;
using VendorAccessGovernance.Core.Entities;

namespace VendorAccessGovernance.Application.Abstractions
{
    public interface IExternalWorkerService
    {
        Task<int> EnsureExternalWorkerAsync(string firstName, string lastName, string email, int vendorId, CancellationToken cancellationToken = default);

        Task<List<ExternalWorkerDto>> GetAllAsync();
    }
}
