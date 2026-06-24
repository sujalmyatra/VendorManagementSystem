using Practical_24.Application.DTOs.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Interfaces
{
    public interface IVendorService
    {
        Task<VendorResponse> CreateAsync(CreateVendorRequest req, CancellationToken token = default);
        Task<VendorResponse?> GetByIdAsync(Guid id, CancellationToken token = default);
        Task<List<VendorResponse>> GetAllAsync(CancellationToken token = default);
        Task DeleteAsync(Guid id, CancellationToken token = default);
    }
}
