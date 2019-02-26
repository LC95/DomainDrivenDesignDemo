namespace Arch.UseCase.UseCases.ContactAgent
{
    public class ContactAgentRequestMessage
    {
        public long HouseId { get; set; }
        public string CustomerEmailAddress { get; set; }
        public long CustomerPhoneNumber { get; set; }
    }
}