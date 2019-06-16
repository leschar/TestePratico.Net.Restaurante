using System;

namespace TestePratico.Net.Restaurante.Core.Events
{
    public class StoredEvent : Event
    {
        public StoredEvent(Event evento, string data)
        {
            Id = Guid.NewGuid();
            AggregateId = evento.AggregateId;
            MessageType = evento.MessageType;
            Data = data;
        }

        // EF Constructor
        protected StoredEvent() { }

        public Guid Id { get; private set; }

        public string Data { get; private set; }
    }
}
