using System;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Events
{
    public class RestauranteRegistradoEvent: BaseEvent
    {
        public RestauranteRegistradoEvent(Guid id,string nome, DateTime dataCadastro, DateTime dataAtualizacao)
        {
            Id = id;
            Nome = nome;
            DataCadastro = dataCadastro;
            DataAtualizacao = dataAtualizacao;

            AggregateId = id;
        }
    }
}
