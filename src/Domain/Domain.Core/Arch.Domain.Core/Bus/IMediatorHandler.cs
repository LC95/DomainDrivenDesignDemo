using MediatR;
using System;
using System.Threading.Tasks;
using Arch.Domain.Core.Commands;
using Arch.Domain.Core.Events;

namespace Arch.Domain.Core.Bus {
    public interface IMediatorHandler {
        Task SendCommand<T>(T command) where T : AbstractCommand;
        Task RaiseEvent<T>(T @event) where T : AbstractEvent;
    }
}
