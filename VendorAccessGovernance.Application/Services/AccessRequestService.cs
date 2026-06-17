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

            return MapToDo(created);
        }

        public async Task<List<AccessRequestDto>> GetAllAsync()
        {
            var items = await _accessRequestRepository.GetAllAsync();

            return items.Select(MapToDo).ToList();
        }

        public async Task<AccessRequestDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var request = await _accessRequestRepository.GetByIdAsync(id);
            return request is null ? null : MapToDo(request);
        }

        public async Task UpdateStatusAsync(int id, UpdateAccessRequestStatusDto dto, CancellationToken ct = default)
        {
            var request = await _accessRequestRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"AccessRequest with id {id} not found.");

            request.Status = dto.NewStatus;
            await _accessRequestRepository.UpdateAsync(request);
        }

        private static AccessRequestDto MapToDo(AccessRequest r) => new()
        {
            Id = r.Id,
            ExternalWorkerid = r.ExternalWorkerId,
            WorkerFullName = r.WorkerRequest is null
                                        ? string.Empty
                                        : $"{r.WorkerRequest.FirstName} {r.WorkerRequest.LastName}".Trim(),
            VendorName = r.WorkerRequest?.VendorName?.NameVendor ?? string.Empty,
            Reason = r.Reason,
            StartDateTime = r.StartDateTime,
            EndDateTime = r.EndDateTime,
            InternalSponsor = r.InternalSponsor,
            Status = r.Status.ToString()
        };
    }
}
