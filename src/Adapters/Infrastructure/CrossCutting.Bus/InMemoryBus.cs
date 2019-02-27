using System.Threading.Tasks;
using Arch.Domain.Core.Bus;
using Arch.Domain.Core.Commands;
using Arch.Domain.Core.Events;
using MediatR;

namespace Arch.Infrastructure.CrossCutting.Bus {
    public sealed class InMemoryBus : IMediatorHandler{
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : AbstractCommand
        {
         return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : AbstractEvent
        {
            return _mediator.Publish(@event);
        }
    }
}
