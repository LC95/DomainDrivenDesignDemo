using Arch.Domain.Core.Events;
using Arch.Domain.Core.Models;
using Arch.Domain.Interfaces;
using Newtonsoft.Json;

namespace Arch.Repository.EntityFramework.EventSourcing {
    public class SqlEventStore : IEventStore {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IUser _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository, IUser user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }


        public void Save<T>(T aEvent) where T : AbstractEvent
        {
            var serilizedData = JsonConvert.SerializeObject(aEvent);
            var storedEvent = new StoredEvent(aEvent, serilizedData, _user.Name);
            _eventStoreRepository.Store(storedEvent);
        }
    }
}
