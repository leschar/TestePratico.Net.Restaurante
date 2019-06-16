using System;
using System.Collections.Generic;
using System.Text;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Events
{
    public class PratoAtualizadoEvent : BaseEvent
    {
        public decimal Valor { get;protected set; }
        public Guid RestauranteId { get;protected set; }
        public PratoAtualizadoEvent(Guid id, string nome, DateTime dataAtualizacao, decimal valor, Guid restauranteId)
        {
            Id = id;
            Nome = nome;
            DataAtualizacao = dataAtualizacao;
            Valor = valor;
            RestauranteId = restauranteId;

            AggregateId = id;
        }
    }
}
