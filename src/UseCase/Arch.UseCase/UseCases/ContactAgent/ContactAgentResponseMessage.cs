using Arch.UseCase.Results;

namespace Arch.UseCase.UseCases.ContactAgent
{
    public class ContactAgentResponseMessage
    {
        public ValidationResult Result { get; }
        public string HouseId { get; }

        public ContactAgentResponseMessage(ValidationResult result, string houseId = null)
        {
            Result = result;
            HouseId = houseId;
        }
    }
}