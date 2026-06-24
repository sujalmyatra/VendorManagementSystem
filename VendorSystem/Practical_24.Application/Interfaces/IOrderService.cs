using Practical_24.Application.DTOs.Invoices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(CreateOrderRequest req, CancellationToken token = default);

    }
}
