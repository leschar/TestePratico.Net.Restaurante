using System;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Commands
{
    public class ExcluirPratoCommand : BaseRestauranteCommand
    {
        public ExcluirPratoCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
