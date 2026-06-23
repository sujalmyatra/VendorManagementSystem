using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Common
{
    public sealed record OrderSucceededEvent(
        Guid InvoiceId,
        Guid PaymentId,
        decimal Amount,
        DateTime OccuredAt
    );
}
