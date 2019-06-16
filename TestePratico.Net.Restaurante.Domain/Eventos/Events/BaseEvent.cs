using System;
using TestePratico.Net.Restaurante.Core.Events;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Events
{
    public abstract class BaseEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataAtualizacao { get; protected set; }
    }
}
