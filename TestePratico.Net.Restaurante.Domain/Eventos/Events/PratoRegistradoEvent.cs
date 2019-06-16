using System;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Events
{
    public class PratoRegistradoEvent : BaseEvent
    {
        public decimal Valor { get; protected set; }
        public Guid RestauranteId { get; protected set; }
        public PratoRegistradoEvent(Guid id, string nome, DateTime dataCadastro, DateTime dataAtualizacao, decimal valor, Guid restauranteId)
        {
            Id = id;
            Nome = nome;
            DataCadastro = dataCadastro;
            DataAtualizacao = dataAtualizacao;
            Valor -= valor;
            RestauranteId = restauranteId;
            AggregateId = id;
        }
    }
}
