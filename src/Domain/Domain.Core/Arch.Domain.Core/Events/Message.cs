using System;
using Arch.Domain.Core.Bus;
using MediatR;

namespace Arch.Domain.Core.Events
{
    public abstract class Message : IRequest<bool> {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}