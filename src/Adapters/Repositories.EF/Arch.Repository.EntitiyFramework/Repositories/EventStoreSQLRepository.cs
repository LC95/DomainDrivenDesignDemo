using System;
using System.Collections.Generic;
using System.Linq;
using Arch.Domain.Core.Events;
using Arch.Domain.Core.Models;
using Arch.Repository.EntityFramework.Context;

namespace Arch.Repository.EntityFramework.Repositories {
    public class EventStoreSqlRepository : IEventStoreRepository{
        private readonly EventStoreSqlContext _context;

        public EventStoreSqlRepository(EventStoreSqlContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
           _context.Dispose();
        }

        public void Store(StoredEvent theEvent)
        {
           _context.StoredEvent.Add(theEvent);
           _context.SaveChanges();
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return _context.StoredEvent.Where(t=>t.AggregateId == aggregateId).ToList();
        }
    }
}
