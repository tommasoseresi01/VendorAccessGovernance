using System;
using System.Collections.Generic;
using System.Text;
using VendorAccessGovernance.Application.DTOs;

namespace VendorAccessGovernance.Application.Abstractions
{
    public interface IAccessRequestService
    {
        Task<AccessRequestDto> CreateAsync(CreateAccessRequestDto dto);
        Task<List<AccessRequestDto>> GetAllAsync();
    }
}
