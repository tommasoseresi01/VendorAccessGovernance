using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Core.Entities;

namespace VendorAccessGovernance.Infrastructure.Persistence.Configurations
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameVendor)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.VatNumber)
                .IsRequired()
                .HasMaxLength(12);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.IsActive)
                .IsRequired();
        }
    }
}
