using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity, IAuditable
    {

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
