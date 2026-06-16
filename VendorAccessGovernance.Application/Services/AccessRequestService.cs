using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Application.Abstractions;
using VendorAccessGovernance.Application.DTOs;
using VendorAccessGovernance.Core.Entities;

namespace VendorAccessGovernance.Application.Services
{
    public class AccessRequestService : IAccessRequestService
    {
        private readonly IAccessRequestRepository _accessRequestRepository;

        public AccessRequestService(IAccessRequestRepository accessRequestRepository)
        {
            _accessRequestRepository = accessRequestRepository;
        }

        public async Task<AccessRequestDto> CreateAsync(CreateAccessRequestDto dto)
        {
            if (dto.EndDateTime <= dto.StartDateTime)
            {
                throw new ArgumentException("The End Date must be after at the start date");
            }

            var entity = new AccessRequest
            {
                ExternalWorkerId = dto.ExternalWorkerId,
                Reason = dto.Reason,
                StartDateTime = dto.StartDateTime,
                EndDateTime = dto.EndDateTime,
                InternalSponsor = dto.InternalSponsor,
                Status = Core.AccessRequestStatus.PendingApproval,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _accessRequestRepository.AddAsync(entity);

            return new AccessRequestDto
            {
                Id = created.Id,
                ExternalWorkerid = created.ExternalWorkerId,
                WorkerFullName = created.WorkerRequest is null
                    ? string.Empty
                    : $"{created.WorkerRequest.FirstName} {created.WorkerRequest.LastName}",
                VendorName = created.WorkerRequest?.VendorName?.NameVendor ?? string.Empty,
                Reason = created.Reason,
                StartDateTime = created.StartDateTime,
                EndDateTime = created.EndDateTime,
                InternalSponsor = created.InternalSponsor,
                Status = created.Status.ToString()
            };
        }

        public async Task<List<AccessRequestDto>> GetAllAsync()
        {
            var items = await _accessRequestRepository.GetAllAsync();

            return items.Select(x => new AccessRequestDto
            {
                Id = x.Id,
                ExternalWorkerid = x.ExternalWorkerId,
                WorkerFullName = $"{x.WorkerRequest.FirstName} {x.WorkerRequest.LastName}",
                VendorName = x.WorkerRequest.VendorName.NameVendor,
                Reason = x.Reason,
                StartDateTime = x.StartDateTime,
                EndDateTime = x.EndDateTime,
                InternalSponsor = x.InternalSponsor,
                Status = x.Status.ToString()
            }).ToList();
        }
    }
}
