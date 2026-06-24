using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Common
{
    public class AuditableSoftDeleteEntity : AuditableEntity, ISoftDeletable
    {
        public bool IsDeleted { get;  set; }

    }
}
