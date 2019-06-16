using System;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Events
{
    public class RestauranteExcluidoEvent : BaseEvent
    {
        public RestauranteExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
