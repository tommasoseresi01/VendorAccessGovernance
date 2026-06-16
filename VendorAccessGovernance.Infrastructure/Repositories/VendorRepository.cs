using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Application.Abstractions;
using VendorAccessGovernance.Core.Entities;
using VendorAccessGovernance.Infrastructure.Persistence;

namespace VendorAccessGovernance.Infrastructure.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly VendorAccessDbContext _context;

        public VendorRepository(VendorAccessDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Vendor vendor, CancellationToken cancellationToken = default)
        {
            await _context.Vendors.AddAsync(vendor, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Vendors.AnyAsync(v => v.NameVendor == name, cancellationToken);
        }

        public async Task<Vendor?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Vendors.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }

        public async Task<Vendor?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Vendors.FirstOrDefaultAsync(v => v.NameVendor == name, cancellationToken);
        }
    }
}
