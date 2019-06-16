using System;
using System.Collections.Generic;
using TestePratico.Net.Restaurante.Core.Events;

namespace TestePratico.Net.Restaurante.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
