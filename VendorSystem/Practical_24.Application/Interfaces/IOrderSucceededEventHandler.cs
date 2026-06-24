using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Interfaces
{
    public interface IOrderSucceededEventHandler
    {
        Task HandleAsync(
        OrderSucceededDomainEvent domainEvent,
        CancellationToken cancellationToken = default);
    }
}
