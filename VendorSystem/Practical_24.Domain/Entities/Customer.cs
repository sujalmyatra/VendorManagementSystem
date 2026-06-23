using Practical_24.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Entities
{
    public class Customer : AuditableSoftDeleteEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public ICollection<Invoice> Invoices { get; private set; } = new List<Invoice>();

    }
}
