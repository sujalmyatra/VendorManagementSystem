using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Events
{
    public class EntityCreatedEventArgs : EventArgs
    {
        public string Name { get; }
        public Guid Id { get; }

        public EntityCreatedEventArgs(string name, Guid id)
        {
            Name = name;
            Id = id;
        }
    }
}
