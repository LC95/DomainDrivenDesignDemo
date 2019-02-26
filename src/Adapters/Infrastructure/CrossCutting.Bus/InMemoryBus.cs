using System.Threading.Tasks;
using Arch.Domain.Core.Bus;
using Arch.Domain.Core.Commands;
using Arch.Domain.Core.Events;
using MediatR;

namespace Arch.Infrastructure.CrossCutting.Bus {
    public sealed class InMemoryBus : IMediatorHandler{
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IMediator mediator, IEventStore eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }

        public Task SendCommand<T>(T command) where T : AbstractCommand
        {
         return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : AbstractEvent
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }
    }
}
