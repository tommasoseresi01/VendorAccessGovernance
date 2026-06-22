using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Application.Abstractions;
using VendorAccessGovernance.Core.Entities;
using VendorAccessGovernance.Infrastructure.Persistence;

namespace VendorAccessGovernance.Infrastructure.Repositories
{
    public class ExternalWorkerRepository : IExternalWorkerRepository
    {

        private readonly VendorAccessDbContext _context;

        public ExternalWorkerRepository(VendorAccessDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ExternalWorker externalWorker, CancellationToken cancellationToken = default)
        {
            await _context.ExternalWorkers.AddAsync(externalWorker, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.ExternalWorkers.AnyAsync(w => w.Email == email, cancellationToken);
        }

        public async Task<ExternalWorker?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.ExternalWorkers.FirstOrDefaultAsync(w => w.Email == email, cancellationToken);
        }

        public async Task<ExternalWorker?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.ExternalWorkers.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
        }

        public async Task<List<ExternalWorker>> GetAllAsync()
        {
            return await _context.ExternalWorkers
                .Include(x => x.VendorName)
                .ToListAsync();
        }
    }
}
