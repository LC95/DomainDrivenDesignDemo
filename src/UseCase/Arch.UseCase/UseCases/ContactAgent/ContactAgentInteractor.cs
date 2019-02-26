using System;
using Arch.Domain;
using Arch.Domain.Repositories;
using Arch.Domain.ValueObjects;
using Arch.UseCase.Port;

namespace Arch.UseCase.UseCases.ContactAgent {
    public class ContactAgentInteractor : IRequestHandler<ContactAgentRequestMessage, ContactAgentResponseMessage> {
        private readonly IHouseRepository _repository;
        private readonly IValidator<ContactAgentRequestMessage> _validator;

        public ContactAgentInteractor(IHouseRepository repository, 
            IValidator<ContactAgentRequestMessage> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public ContactAgentResponseMessage Handle(ContactAgentRequestMessage request)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid) 
                return new ContactAgentResponseMessage(validationResult);
            var house = _repository.Get(request.HouseId);
            house.RegisterInterest(new Interest
            {
                CustomerEmailAddress = request.CustomerEmailAddress,
                CustomerPhoneNumber = request.CustomerPhoneNumber,
                CreationDate = DateTime.Now
            });

            _repository.Save(house);
            return new ContactAgentResponseMessage(validationResult,request.HouseId);
        }

    }
}
