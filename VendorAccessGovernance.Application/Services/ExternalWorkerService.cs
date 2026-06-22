using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Application.Abstractions;
using VendorAccessGovernance.Application.DTOs;
using VendorAccessGovernance.Core.Entities;

namespace VendorAccessGovernance.Application.Services
{
    public class ExternalWorkerService : IExternalWorkerService
    {

        private readonly IExternalWorkerRepository _externalWorkerRepository;

        public ExternalWorkerService(IExternalWorkerRepository externalWorkerRepository)
        {
            _externalWorkerRepository = externalWorkerRepository;
        }

        public async Task<int> EnsureExternalWorkerAsync(string firstName, string lastName, string email, int vendorId, CancellationToken cancellationToken = default)
        {
            // Normalizzo le stringhe
            var normalizedEmail = email.Trim();         
            var normalizedFirstName = firstName.Trim();
            var normalizedLastName = lastName.Trim();


            // controllo se il lavoratore esterno esiste
            var existing = await _externalWorkerRepository.GetByEmailAsync(normalizedEmail, cancellationToken);

            if (existing is not null)
            {
                return existing.Id;
            }

            // se non esiste lo creo

            var worker = new ExternalWorker
            {
                FirstName = normalizedFirstName,
                LastName = normalizedLastName,
                Email = normalizedEmail,
                VendorId = vendorId
            };

            await _externalWorkerRepository.AddAsync(worker, cancellationToken);

            return worker.Id;
        }

        public async Task<List<ExternalWorkerDto>> GetAllAsync()
        {
            var items = await _externalWorkerRepository.GetAllAsync();

            return items.Select(MapToDo).ToList();
        }

        private static ExternalWorkerDto MapToDo(ExternalWorker r) => new()
        {
            Id = r.Id,
            FirstName = r.FirstName,
            LastName = r.LastName,
            Email = r.Email,
            PhoneNumber = r.PhoneNumber,
            VendorName = r.VendorName?.NameVendor
        };
    }
}
