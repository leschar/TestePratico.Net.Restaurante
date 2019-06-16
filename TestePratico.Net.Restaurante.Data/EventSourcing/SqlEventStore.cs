using Newtonsoft.Json;
using TestePratico.Net.Restaurante.Core.Events;
using TestePratico.Net.Restaurante.Data.Repository.EventSourcing;
using TestePratico.Net.Restaurante.Domain.Interfaces;

namespace TestePratico.Net.Restaurante.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void SalvarEvento<T>(T evento) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(evento);

            var storedEvent = new StoredEvent(
                evento,
                serializedData);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
