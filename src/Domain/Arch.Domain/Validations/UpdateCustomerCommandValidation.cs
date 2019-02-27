using Arch.Domain.Commands;

namespace Arch.Domain.Validations {
    internal class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand> {
        public UpdateCustomerCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
