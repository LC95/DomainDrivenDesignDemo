using Arch.UseCase.Results;

namespace Arch.UseCase.UseCases.ContactAgent
{
    public class ContactAgentResponseMessage
    {
        public ValidationResult ValidationResult { get; }
        public long? HouseId { get; }

        public ContactAgentResponseMessage(ValidationResult validationResult, long? houseId = null)
        {
            ValidationResult = validationResult;
            HouseId = houseId;
        }
    }
}