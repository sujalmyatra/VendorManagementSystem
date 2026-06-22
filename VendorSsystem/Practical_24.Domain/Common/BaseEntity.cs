using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
    }
}
