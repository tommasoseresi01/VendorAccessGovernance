using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Core.Entities;

namespace VendorAccessGovernance.Infrastructure.Persistence.Configurations
{
    public class ExternalWorkerConfiguration : IEntityTypeConfiguration<ExternalWorker>
    {
        public void Configure(EntityTypeBuilder<ExternalWorker> builder)
        {
            builder.ToTable("External Workers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(x => x.VendorName)
                .WithMany(x => x.MyWorkers)
                .HasForeignKey(x => x.VendorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
