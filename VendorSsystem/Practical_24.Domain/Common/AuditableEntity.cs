using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public AuditableEntity(string createdBy)
        {
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public DateTime CreatedAt { get; }
        public string CreatedBy {  get; }
        public DateTime? UpdatedAt { get; }
        public string? UpdatedBy {  get; }
    }
}
