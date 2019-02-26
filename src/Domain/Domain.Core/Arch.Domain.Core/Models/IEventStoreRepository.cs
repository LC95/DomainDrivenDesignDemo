using Arch.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace Arch.Domain.Core.Models {
    public interface IEventStoreRepository : IDisposable {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
