using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Application.Abstractions;
using VendorAccessGovernance.Core.Entities;
using VendorAccessGovernance.Infrastructure.Persistence;

namespace VendorAccessGovernance.Infrastructure.Repositories
{
    public class AccessRequestRepository : IAccessRequestRepository
    {
        private readonly VendorAccessDbContext _context;

        public AccessRequestRepository(VendorAccessDbContext context)
        {
            _context = context;
        }

        public async Task<AccessRequest> AddAsync(AccessRequest accessRequest)
        {
            _context.AccessRequests.Add(accessRequest);
            await _context.SaveChangesAsync();

            return await _context.AccessRequests
                .Include(x => x.WorkerRequest)
                .ThenInclude(x => x.VendorName)
                .FirstAsync(x => x.Id == accessRequest.Id);
        }

        public async Task<List<AccessRequest>> GetAllAsync()
        {
            return await _context.AccessRequests
                .Include(x => x.WorkerRequest)
                .ThenInclude(x => x.VendorName)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}
