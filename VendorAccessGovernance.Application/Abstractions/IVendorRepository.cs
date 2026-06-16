using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Core.Entities;

namespace VendorAccessGovernance.Application.Abstractions
{
    public interface IVendorRepository
    {
        Task<Vendor?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<Vendor?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);


        // This method is used for adding a new vendor to the database. 
        Task AddAsync(Vendor vendor, CancellationToken cancellationToken = default);
    }
}
