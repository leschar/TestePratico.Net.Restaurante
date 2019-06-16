using System;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Events
{
    public class RestauranteAtualizadoEvent : BaseEvent
    {
        public RestauranteAtualizadoEvent(Guid id, string nome,  DateTime dataAtualizacao)
        {
            Id = id;
            Nome = nome;
            DataAtualizacao = dataAtualizacao;

            AggregateId = id;
        }
    }
}
