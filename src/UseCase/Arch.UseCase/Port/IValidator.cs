using System;
using System.Collections.Generic;
using System.Text;
using Arch.UseCase.Results;
using Arch.UseCase.UseCases.ContactAgent;

namespace Arch.UseCase.Port {
    public interface IValidator<TData> {
        ValidationResult Validate(TData request);
    }
}
