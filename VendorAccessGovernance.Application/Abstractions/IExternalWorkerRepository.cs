using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Core.Entities;

namespace VendorAccessGovernance.Application.Abstractions
{
    public interface IExternalWorkerRepository
    {
        Task<ExternalWorker?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<ExternalWorker?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task AddAsync(ExternalWorker externalWorker, CancellationToken cancellationToken = default);

        Task<List<ExternalWorker>> GetAllAsync();


    }
}
