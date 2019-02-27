using System;
using System.Collections.Generic;
using System.Text;
using Arch.Domain.Core.Events;

namespace Arch.Domain.Events {
    public class CustomerRemovedEvent : AbstractEvent{
        public CustomerRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
