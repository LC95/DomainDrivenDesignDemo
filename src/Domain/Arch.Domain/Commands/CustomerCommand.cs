using System;
using Arch.Domain.Core.Commands;

namespace Arch.Domain.Commands
{
    public abstract class CustomerCommand : AbstractCommand {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime BirthDate { get; protected set; }
    }
}