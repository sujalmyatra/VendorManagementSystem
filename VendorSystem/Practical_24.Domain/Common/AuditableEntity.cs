using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity, IAuditable
    {

        public DateTime CreatedAt { get; }
        public string CreatedBy { get; } = string.Empty;
        public DateTime? UpdatedAt { get; }
        public string? UpdatedBy {  get; }
    }
}
