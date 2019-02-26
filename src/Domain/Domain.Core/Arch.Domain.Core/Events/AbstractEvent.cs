using System;
using MediatR;

namespace Arch.Domain.Core.Events
{
    public abstract class AbstractEvent : Message, INotification {
        public DateTime CreateTime { get;}
        protected AbstractEvent()
        {
            CreateTime = DateTime.Now;
        }
    }
}