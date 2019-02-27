using Arch.Domain.Commands;

namespace Arch.Domain.Validations {
    public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand> {
        public RemoveCustomerCommandValidation()
        {
            ValidateId();
        }
    }
}
