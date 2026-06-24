using Practical_24.Application.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerResponse> CreateAsync(CreateCustomerRequest req, CancellationToken token = default);
        Task<CustomerResponse?> GetByIdAsync(Guid id, CancellationToken token = default);
        Task<List<CustomerResponse>> GetAllAsync(CancellationToken token = default);
        Task DeleteAsync(Guid id, CancellationToken token = default);
    }
}
