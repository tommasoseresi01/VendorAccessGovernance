using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using VendorAccessGovernance.Application.Abstractions;
using VendorAccessGovernance.Application.DTOs;
using VendorAccessGovernance.Core.Entities;

namespace VendorAccessGovernance.Application.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
        public async Task<int> EnsureVendorAsync(string vendorName, CancellationToken cancellationToken = default)
        {
            var normalizedName = vendorName.Trim(); // il metodo trim serve per pulire la stringa in caso ad esempio di spazi all'inizio o alla fine.

            // 1. Controllo se esiste (puoi usare Exists o direttamente Get)

            var existing = await _vendorRepository.GetByNameAsync(normalizedName, cancellationToken);

            if (existing is not null)
            {
                return existing.Id;
            }

            // 2. Se non esiste, lo creo
            var vendor = new Vendor
            {
                NameVendor = normalizedName
            };

            await _vendorRepository.AddAsync(vendor, cancellationToken);

            return vendor.Id;
        }

        public async Task<List<VendorDto>> GetAllAsync()
        {
            var items = await _vendorRepository.GetAllAsync();

            return items.Select(MapToDo).ToList();
        }

        private static VendorDto MapToDo(Vendor r) => new()
        {
            Id = r.Id,
            NameVendor = r.NameVendor,
            VatNumber = r.VatNumber,
            Email = r.Email,
            IsActive = r.IsActive
        };
    }
}
