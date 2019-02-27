using System;
using System.Collections.Generic;
using System.Text;
using Arch.Domain.Commands;
using FluentValidation.Results;

namespace Arch.Domain.Validations {
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand> {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
