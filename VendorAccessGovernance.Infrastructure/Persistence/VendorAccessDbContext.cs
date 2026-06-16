using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VendorAccessGovernance.Core.Entities;

namespace VendorAccessGovernance.Infrastructure.Persistence
{
    public class VendorAccessDbContext : DbContext
    {
        public VendorAccessDbContext(DbContextOptions<VendorAccessDbContext> options) : base(options)
        {
        }

        public DbSet<Vendor> Vendors => Set<Vendor>();
        public DbSet<ExternalWorker> ExternalWorkers => Set<ExternalWorker>();
        public DbSet<AccessRequest> AccessRequests => Set<AccessRequest>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendorAccessDbContext).Assembly);
        }
    }
}
