using System;
using Arch.Domain.Core.Events;
using FluentValidation.Results;

namespace Arch.Domain.Core.Commands
{
    public abstract class AbstractCommand : Message {
        public DateTime CreateTime { get; }
        public ValidationResult ValidationResult { get; set; }
        protected AbstractCommand()
        {
            CreateTime = DateTime.Now;
        }
        public abstract bool IsValid();
    }
}