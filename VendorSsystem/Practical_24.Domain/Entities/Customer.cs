using Practical_24.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Entities
{
    public class Customer : AuditableEntity, ISoftDeletable
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public bool IsDeleted { get; private set; }

        public Customer(string name, string email, string createdBy) :base(createdBy)
        {
            Name = name;
            Email = email;
        }

    }
}
