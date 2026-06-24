using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Events
{
    public class ApplicationEvents
    {
        //Simple
        //public event Action? EntityCreated;
        //public event Action? OrderSucceeded;

        //public void RaiseEntityCreated()
        //{
        //    EntityCreated?.Invoke();
        //}
        //public void RaiseOrderSucceeded()
        //{
        //    OrderSucceeded?.Invoke();
        //}

        //Detailed

        public event EventHandler<EntityCreatedEventArgs>? EntityCreated;
        public event EventHandler<OrderSucceededEventArgs>? OrderSucceeded;

        public void RaiseEntityCreated(string name, Guid id)
        {
            var args = new EntityCreatedEventArgs(name, id);
            EntityCreated?.Invoke(this, args);
        }
        public void RaiseOrderSucceeded(Guid invoiceId, Guid paymentId, decimal amt)
        {
            var args = new OrderSucceededEventArgs(invoiceId, paymentId, amt);
            OrderSucceeded?.Invoke(this, args);
        }
    }
}
