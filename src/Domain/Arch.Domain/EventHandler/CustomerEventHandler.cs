using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arch.Domain.Events;
using MediatR;

namespace Arch.Domain.EventHandler {
    public class CustomerEventHandler :
         INotificationHandler<CustomerRegisteredEvent>,
         INotificationHandler<CustomerUpdatedEvent>,
         INotificationHandler<CustomerRemovedEvent> {
        public Task Handle(CustomerUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            Console.WriteLine(message.Id);
            return Task.CompletedTask;
        }

        public Task Handle(CustomerRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Console.WriteLine(message.Id);

            return Task.CompletedTask;
        }

        public Task Handle(CustomerRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail
            Console.WriteLine(message.Id);

            return Task.CompletedTask;
        }
    }
}
