using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Core.Entities;

namespace VendorAccessGovernance.Infrastructure.Persistence.Configurations
{
    public class AccessRequestConfiguration : IEntityTypeConfiguration<AccessRequest>
    {
        public void Configure(EntityTypeBuilder<AccessRequest> builder)
        {
            builder.ToTable("AccessRequests");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Reason)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.InternalSponsor)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasOne(x => x.WorkerRequest)
                .WithMany(x => x.AccessRequests)
                .HasForeignKey(x => x.ExternalWorkerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
