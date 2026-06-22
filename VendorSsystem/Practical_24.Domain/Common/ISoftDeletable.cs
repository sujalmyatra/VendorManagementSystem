using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Common
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }
    }
}
