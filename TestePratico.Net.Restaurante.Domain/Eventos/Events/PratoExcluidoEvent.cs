using System;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Events
{
    public class PratoExcluidoEvent : BaseEvent
    {
        public PratoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
